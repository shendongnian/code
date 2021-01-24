            bool saveAssets = false;
            foreach (var editorSkin in Enum.GetValues(typeof(EditorSkin)).Cast<EditorSkin>())
            {
                string file = Path.Combine("Assets", "StreamingAssets", $"{editorSkin.ToString()}.guiskin");
                if (!File.Exists(file))
                {
                    AssetDatabase.CreateAsset(Instantiate(EditorGUIUtility.GetBuiltinSkin(editorSkin)), file);
                    saveAssets = true;
                }
            }
            if (saveAssets)
                AssetDatabase.SaveAssets();
