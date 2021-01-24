    #if UNITY_EDITOR
        using System.IO;
        using UnityEditor;
        using UnityEngine;
        public static class YourExtensions
        {
            [MenuItem("YourMenu/GenerateAssets")]
            private static void GenerateAssets()
            {
                // TODO Get and parse required information e.g. from Database / Xml or Text file
                // I'ld simply make a new class for that like "CardInformation"
                // List<CardInformation>() cardlist = new List<CardInformation>();
                // Somehow receive your information
                // cardlist.add(new CardInformation(parameters));
                // TODO Generate Scriptableobjects
                // foreach(var cardInfo in cardlist){
                        YourScriptableObjectClass asset = ScriptableObject.CreateInstance<YourScriptableObjectClass > ();
		                string path = AssetDatabase.GetAssetPath (Selection.activeObject);
		                if (path == "") 
		                {
			                path = "Assets";
		                } 
		                else if (Path.GetExtension (path) != "") 
		                {
			                path = path.Replace (Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), "");
		                }
 
		                string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/New " + typeof(YourScriptableObjectClass ).ToString() + ".asset");
 
		                AssetDatabase.CreateAsset (asset, assetPathAndName);
 
		                AssetDatabase.SaveAssets ();
        	            AssetDatabase.Refresh();
		                EditorUtility.FocusProjectWindow ();
		                Selection.activeObject = asset;
                        // TODO here set your passed parameters for this asset
                        // asset.parameter = cardInfo.parameters;
                // end foreach
            }
        }
    #endif
