    public void WriteCustomEditorFile ()
    {
      // create all missing directories in the hierarchy
      Directory.CreateDirectory (Path.GetDirectoryName (editorPath));
      // write file
      File.WriteAllText (editorPath, BuildCustomEditorCode(scriptName));
      // let Asset DB pick up the new file
      AssetDatabase.Refresh();
      // highlight in GUI
      var os = AssetDatabase.LoadAllAssetsAtPath(editorRelativeAssetPath);
      EditorGUIUtility.PingObject (os[0]);
      // log
      Debug.Log("Created new custom Editor at: " + editorRelativeAssetPath);
    }
