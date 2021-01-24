    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEditor;
    using UnityEditor.Compilation;
    using UnityEngine;
    
    
    [InitializeOnLoad]
    public static class GenerateAssemblies
    {
        private static string BATCH_MODE_PARAM = "-batchmode";
        private const string REPLACE_ASSEMBLY_PARAM = "-replaceassembly";
    
        static GenerateAssemblies()
        {
            List<String> args = Environment.GetCommandLineArgs().ToList();
    
            if (args.Any(arg => arg.ToLower().Equals(BATCH_MODE_PARAM)))
            {
                Debug.LogFormat("GenerateAssemblies will try to parse the command line to replace assemblies.\n" +
                   "\t Use {0} \"assemblyname\" for every assembly you wish to replace"
                   , REPLACE_ASSEMBLY_PARAM);
            }
    
            if (args.Any(arg => arg.ToLower().Equals(REPLACE_ASSEMBLY_PARAM))) // is a replacement requested ?
            {
                int lastIndex = 0;
                while (lastIndex != -1)
                {
                    lastIndex = args.FindIndex(lastIndex, arg => arg.ToLower().Equals(REPLACE_ASSEMBLY_PARAM));
                    if (lastIndex >= 0 && lastIndex + 1 < args.Count)
                    {
                        string assemblyToReplace = args[lastIndex + 1];
                        if (!assemblyToReplace.EndsWith(ReplaceAssemblies.ASSEMBLY_EXTENSION))
                            assemblyToReplace = assemblyToReplace + ReplaceAssemblies.ASSEMBLY_EXTENSION;
                        ReplaceAssemblies.instance.AddAssemblyFileToReplace(assemblyToReplace);
                        Debug.LogFormat("Added assembly {0} to the list of assemblies to replace.", assemblyToReplace);
                        lastIndex++;
                    }
                }
                CompilationPipeline.assemblyCompilationFinished += ReplaceAssemblies.instance.ReplaceAssembly; /* This serves as callback after Unity as compiled an assembly */
    
                Debug.Log("Forcing recompilation of all scripts");
                // to force recompilation
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone) + ";DUMMY_SYMBOL");
                AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
            }
        }
    
    }
