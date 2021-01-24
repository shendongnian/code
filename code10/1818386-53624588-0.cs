        using UnityEngine;
        using UnityEditor;
        using UnityEditor.Callbacks;
        
        public class MyBuildPostprocessor 
        {
            [PostProcessBuildAttribute(1)]
            public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) 
            {
                Debug.Log( pathToBuiltProject );
                File.Copy("Oringal File",pathToBuiltProject + "\play_data\plugins\" + Your dll);
            }
        }
