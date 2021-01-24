    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEditor;
    using System.IO;
    
    
    /*
    Detects possible special script names
    By Programmer
    https://stackoverflow.com/users/3785314/programmer
    */
    
    public class SpecialIconLister : MonoBehaviour
    {
        [MenuItem("Programmer/Show Special Icons")]
        static void MainProc()
        {
            if (EditorUtility.DisplayDialog("Log and copy special Icon names?",
                   "Are you sure you want to log and copy spacial icons to the clipboard?",
                   "Yes", "Cancel"))
            {
    
                if (IsPlayingInEditor())
                    return;
    
                //"unity default resources" contains models, materials an shaders
                //"unity editor resources" contains most icons lile GameManager Search and so on 
                //"unity_builtin_extra" contains UI images and Shaders
    
                //Files to copy to the Resources folder in the project
                string file1 = UnityEditorResourcesFilePath("unity default resources");
                string file2 = UnityEditorResourcesFilePath("unity editor resources");
                string file3 = UnityEditorResourcesFilePath("unity_builtin_extra");
    
                string dest1 = UnityProjectResourcesPath("unity default resources.asset");
                string dest2 = UnityProjectResourcesPath("unity editor resources.asset");
                string dest3 = UnityProjectResourcesPath("unity_builtin_extra.asset");
    
                //Create the Resources folder in the Project folder if it doesn't exist
                VerifyResourcesFolder(dest1);
                VerifyResourcesFolder(dest2);
                VerifyResourcesFolder(dest3);
    
                //Copy each file to the resouces folder
                if (!File.Exists(dest1))
                    FileUtil.CopyFileOrDirectoryFollowSymlinks(file1, dest1);
                if (!File.Exists(dest2))
                    FileUtil.CopyFileOrDirectoryFollowSymlinks(file2, dest2);
                if (!File.Exists(dest3))
                    FileUtil.CopyFileOrDirectoryFollowSymlinks(file3, dest3);
    
                Debug.unityLogger.logEnabled = false;
    
                //Refresh Editor
                AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);
    
                //Load every object in that folder
                Resources.LoadAll("");
    
                //List the special icons
                GetSpecialIcons();
    
                CleanUp(dest1);
                CleanUp(dest2);
                CleanUp(dest3);
    
                //Refresh Editor
                AssetDatabase.Refresh();
                Resources.UnloadUnusedAssets();
                AssetDatabase.Refresh();
                Debug.unityLogger.logEnabled = false;
            }
        }
    
        static void SelectAsset(string resourcesFilePath)
        {
            UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath(resourcesFilePath, typeof(UnityEngine.Object));
            Selection.activeObject = obj;
        }
    
        static string AsoluteToRelative(string absolutePath)
        {
            string relativePath = null;
            if (absolutePath.StartsWith(Application.dataPath))
            {
                relativePath = "Assets" + absolutePath.Substring(Application.dataPath.Length);
            }
            return relativePath;
        }
    
        static void GetSpecialIcons()
        {
            //Get All Editor icons 
            List<UnityEngine.Object> allIcons;
            allIcons = new List<UnityEngine.Object>(Resources.FindObjectsOfTypeAll(typeof(Texture)));
            allIcons = allIcons.OrderBy(a => a.name, StringComparer.OrdinalIgnoreCase).ToList();
    
    
            //Get special icons from the icons
            List<string> specialIconsList = new List<string>();
            string suffix = " Icon";
            foreach (UnityEngine.Object icList in allIcons)
            {
                if (!IsEditorBuiltinIcon(icList))
                    continue;
    
                //Check if icon name ends with the special suffix
                if (icList.name.EndsWith(suffix))
                {
                    //Remove suffix from the icon name then add it to the special icons List if it doesn't exist yet
                    string sIcon = icList.name.Substring(0, icList.name.LastIndexOf(suffix));
                    if (!specialIconsList.Contains(sIcon))
                        specialIconsList.Add(sIcon);
                }
            }
            //Sort special icons from the icons
            specialIconsList = specialIconsList.OrderBy(a => a, StringComparer.OrdinalIgnoreCase).ToList();
    
            Debug.unityLogger.logEnabled = true;
            Debug.Log("Total # Icons found: " + allIcons.Count);
            Debug.Log("Special # Icons found: " + specialIconsList.Count);
    
            //Add new line after each icon for easy display or copying
            string specialIcon = string.Join(Environment.NewLine, specialIconsList.ToArray());
            Debug.Log(specialIcon);
    
            //Copy the special icon names to the clipboard
            GUIUtility.systemCopyBuffer = specialIcon;
    
            Debug.LogWarning("Special Icon names copied to cilpboard");
            Debug.LogWarning("Hold Ctrl+V to paste on any Editor");
        }
    
        static string UnityEditorResourcesFilePath(string fileName = null)
        {
            //C:/Program Files/Unity/Editor/Unity.exe
            string tempPath = EditorApplication.applicationPath;
            //C:/Program Files/Unity/Editor
            tempPath = Path.GetDirectoryName(tempPath);
            tempPath = Path.Combine(tempPath, "Data");
            tempPath = Path.Combine(tempPath, "Resources");
            //C:\Program Files\Unity\Editor\Data\Resources
            if (fileName != null)
                tempPath = Path.Combine(tempPath, fileName);
            return tempPath;
        }
    
        static string UnityProjectResourcesPath(string fileName = null)
        {
            string tempPath = Application.dataPath;
            tempPath = Path.Combine(tempPath, "Resources");
            if (fileName != null)
                tempPath = Path.Combine(tempPath, fileName);
            return tempPath;
        }
    
        static bool IsEditorBuiltinIcon(UnityEngine.Object icon)
        {
            if (!EditorUtility.IsPersistent(icon))
                return false;
    
            return true;
        }
    
        static void VerifyResourcesFolder(string resourcesPath)
        {
            //Create Directory if it does not exist
            if (!Directory.Exists(Path.GetDirectoryName(resourcesPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(resourcesPath));
            }
        }
    
        static bool IsPlayingInEditor()
        {
            return (Application.isPlaying && Application.isEditor);
        }
    
        static void CleanUp(string resourcesFilePath)
        {
            FileAttributes attr = File.GetAttributes(resourcesFilePath);
            if (!((attr & FileAttributes.Directory) == FileAttributes.Directory)
                && File.Exists(resourcesFilePath))
            {
                FileUtil.DeleteFileOrDirectory(resourcesFilePath);
            }
            System.GC.Collect();
        }
    
    }
