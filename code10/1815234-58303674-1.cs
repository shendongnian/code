    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using UnityEditor;
    using UnityEditor.Compilation;
    using UnityEngine;
    
    public class ReplaceAssemblies : ScriptableSingleton<ReplaceAssemblies>
    {
    
        public static string ASSEMBLY_EXTENSION = ".dll";
        public static string ASSEMBLY_DEFINITION_EXTENSION = ".asmdef";
    
        [SerializeField]
        private List<String> assembliesFilesToReplace = new List<string>();
    
        [SerializeField]
        private List<string> pathsOfAssemblyFilesInAssetFolder = new List<string>();
        [SerializeField]
        private List<string> pathsOfAssemblyFilesCreatedByUnity = new List<string>();
    
        [SerializeField]
        private string tempSourceFilePath;
    
        private static readonly string[] fileListPath = { "*.prefab", "*.unity", "*.asset" };
    
    
        public string TempSourceFilePath
        {
            get
            {
                if (String.IsNullOrEmpty(tempSourceFilePath))
                {
                    tempSourceFilePath = FileUtil.GetUniqueTempPathInProject();
                }
    
                return tempSourceFilePath;
            }
        }
    
        void OnEnable()
        {
            Debug.Log("temp dir : " + TempSourceFilePath);
        }
    
        public void ReplaceAssembly(string assemblyPath, CompilerMessage[] messages)
        {
            string assemblyFileName = assembliesFilesToReplace.Find(assembly => assemblyPath.EndsWith(assembly));
            // is this one of the assemblies we want to replace ?
            if (!String.IsNullOrEmpty(assemblyFileName))
            {
                string[] assemblyDefinitionFilePaths = Directory.GetFiles(".", Path.GetFileNameWithoutExtension(assemblyFileName) + ASSEMBLY_DEFINITION_EXTENSION, SearchOption.AllDirectories);
                if (assemblyDefinitionFilePaths.Length > 0)
                {
                    string assemblyDefinitionFilePath = assemblyDefinitionFilePaths[0];
                    ReplaceAssembly(assemblyDefinitionFilePath);
                }
            }
        }
    
        public void AddAssemblyFileToReplace(string assemblyFile)
        {
            assembliesFilesToReplace.Add(assemblyFile);
        }
    
        private void ReplaceAssembly(string assemblyDefinitionFilePath)
        {
            Debug.LogFormat("Replacing scripts for assembly definition file {0}", assemblyDefinitionFilePath);
            string asmdefDirectory = Path.GetDirectoryName(assemblyDefinitionFilePath);
            string assemblyName = Path.GetFileNameWithoutExtension(assemblyDefinitionFilePath);
            Assembly assemblyToReplace = CompilationPipeline.GetAssemblies().ToList().Find(assembly => assembly.name.ToLower().Equals(assemblyName.ToLower()));
            string assemblyPath = assemblyToReplace.outputPath;
            string assemblyFileName = Path.GetFileName(assemblyPath);
            string[] assemblyFilePathInAssets = Directory.GetFiles("./Assets", assemblyFileName, SearchOption.AllDirectories);
    
            // save the guid/classname correspondance of the scripts that we will remove
            Dictionary<string, string> oldGUIDToClassNameMap = new Dictionary<string, string>();
            if (assemblyFilePathInAssets.Length <= 0)
            {
                // Move all script files outside the asset folder
                foreach (string sourceFile in assemblyToReplace.sourceFiles)
                {
                    string tempScriptPath = Path.Combine(TempSourceFilePath, sourceFile);
                    Directory.CreateDirectory(Path.GetDirectoryName(tempScriptPath));
                    if (!File.Exists(sourceFile))
                        Debug.LogErrorFormat("File {0} does not exist while the assembly {1} references it.", sourceFile, assemblyToReplace.name);
                    Debug.Log("will move " + sourceFile + " to " + tempScriptPath);
                    // save the guid of the file because we may need to replace it later
                    MonoScript monoScript = AssetDatabase.LoadAssetAtPath<MonoScript>(sourceFile);
                    if (monoScript != null && monoScript.GetClass() != null)
                        oldGUIDToClassNameMap.Add(AssetDatabase.AssetPathToGUID(sourceFile), monoScript.GetClass().FullName);
                    FileUtil.MoveFileOrDirectory(sourceFile, tempScriptPath);
                }
    
                Debug.Log("Map of GUID/Class : \n" + String.Join("\n", oldGUIDToClassNameMap.Select(pair => pair.Key + " : " + pair.Value).ToArray()));
    
                string finalAssemblyPath = Path.Combine(asmdefDirectory, assemblyFileName);
                Debug.Log("will move " + assemblyPath + " to " + finalAssemblyPath);
                FileUtil.MoveFileOrDirectory(assemblyPath, finalAssemblyPath);
                string tempAsmdefPath = Path.Combine(TempSourceFilePath, Path.GetFileName(assemblyDefinitionFilePath));
                Debug.Log("will move " + assemblyDefinitionFilePath + " to " + tempAsmdefPath);
                FileUtil.MoveFileOrDirectory(assemblyDefinitionFilePath, tempAsmdefPath);
                // Rename the asmdef meta file to the dll meta file so that the dll guid stays the same
                FileUtil.MoveFileOrDirectory(assemblyDefinitionFilePath + ".meta", finalAssemblyPath + ".meta");
                pathsOfAssemblyFilesInAssetFolder.Add(finalAssemblyPath);
                pathsOfAssemblyFilesCreatedByUnity.Add(assemblyPath);
    
    
                // We need to refresh before accessing the assets in the new assembly
                AssetDatabase.Refresh();
    
    
                // We need to remove .\ when using LoadAsslAssetsAtPath
                string cleanFinalAssemblyPath = finalAssemblyPath.Replace(".\\", "");
                var assetsInAssembly = AssetDatabase.LoadAllAssetsAtPath(cleanFinalAssemblyPath);
    
                // list all components in the assembly file. 
                var assemblyObjects = assetsInAssembly.OfType<MonoScript>().ToArray();
    
                // save the new GUID and file ID for the MonoScript in the new assembly
                Dictionary<string, KeyValuePair<string, long>> newMonoScriptToIDsMap = new Dictionary<string, KeyValuePair<string, long>>();
                // for each component, replace the guid and fileID file
                for (var i = 0; i < assemblyObjects.Length; i++)
                {
                    long dllFileId;
                    string dllGuid = null;
                    if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(assemblyObjects[i], out dllGuid, out dllFileId))
                    {
                        string fullClassName = assemblyObjects[i].GetClass().FullName;
                        newMonoScriptToIDsMap.Add(fullClassName, new KeyValuePair<string, long>(dllGuid, dllFileId));
                    }
                }
    
                Debug.Log("Map of Class/GUID:FILEID : \n" + String.Join("\n", newMonoScriptToIDsMap.Select(pair => pair.Key + " : " + pair.Value.Key + " - " + pair.Value.Value).ToArray()));
    
                ReplaceIdsInAssets(oldGUIDToClassNameMap, newMonoScriptToIDsMap);
            }
    
    
            else
            {
                Debug.Log("Already found an assembly file named " + assemblyFileName + " in asset folder");
            }
        }
    
        /// <summary>
        /// Replace ids in all asset files using the given maps
        /// </summary>
        /// <param name="oldGUIDToClassNameMap">Maps GUID to be replaced => FullClassName</param>
        /// <param name="newMonoScriptToIDsMap">Maps FullClassName => new GUID, new FileID</param>
        private static void ReplaceIdsInAssets(Dictionary<string, string> oldGUIDToClassNameMap, Dictionary<string, KeyValuePair<string, long>> newMonoScriptToIDsMap)
        {
            StringBuilder output = new StringBuilder("Report of replaced ids : \n");
            // list all the potential files that might need guid and fileID update
            List<string> fileList = new List<string>();
            foreach (string extension in fileListPath)
            {
                fileList.AddRange(Directory.GetFiles(Application.dataPath, extension, SearchOption.AllDirectories));
            }
            foreach (string file in fileList)
            {
                string[] fileLines = File.ReadAllLines(file);
    
                for (int line = 0; line < fileLines.Length; line++)
                {
                    //find all instances of the string "guid: " and grab the next 32 characters as the old GUID
                    if (fileLines[line].Contains("guid: "))
                    {
                        int index = fileLines[line].IndexOf("guid: ") + 6;
                        string oldGUID = fileLines[line].Substring(index, 32); // GUID has 32 characters.
                        if (oldGUIDToClassNameMap.ContainsKey(oldGUID) && newMonoScriptToIDsMap.ContainsKey(oldGUIDToClassNameMap[oldGUID]))
                        {
                            fileLines[line] = fileLines[line].Replace(oldGUID, newMonoScriptToIDsMap[oldGUIDToClassNameMap[oldGUID]].Key);
                            output.AppendFormat("File {0} : Found GUID {1} of class {2}. Replaced with new GUID {3}.", file, oldGUID, oldGUIDToClassNameMap[oldGUID], newMonoScriptToIDsMap[oldGUIDToClassNameMap[oldGUID]].Key);
                            if (fileLines[line].Contains("fileID: "))
                            {
                                index = fileLines[line].IndexOf("fileID: ") + 8;
                                int index2 = fileLines[line].IndexOf(",", index);
                                string oldFileID = fileLines[line].Substring(index, index2 - index); // GUID has 32 characters.
                                fileLines[line] = fileLines[line].Replace(oldFileID, newMonoScriptToIDsMap[oldGUIDToClassNameMap[oldGUID]].Value.ToString());
                                output.AppendFormat("Replaced fileID {0} with {1}", oldGUID, newMonoScriptToIDsMap[oldGUIDToClassNameMap[oldGUID]].Value.ToString());
                            }
                            output.Append("\n");
                        }
                    }
                }
                //Write the lines back to the file
                File.WriteAllLines(file, fileLines);
            }
            Debug.Log(output.ToString());
        }
    
        [MenuItem("Tools/Replace Assembly")]
        public static void ReplaceAssemblyMenu()
        {
            string assemblyDefinitionFilePath = EditorUtility.OpenFilePanel(
                title: "Select Assembly Definition File",
                directory: Application.dataPath,
                extension: ASSEMBLY_DEFINITION_EXTENSION.Substring(1));
            if (assemblyDefinitionFilePath.Length == 0)
                return;
    
            instance.ReplaceAssembly(assemblyDefinitionFilePath);
    
        }
    }
        
