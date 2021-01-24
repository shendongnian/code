    [MenuItem ("Assets/Add Custom Editor %#e", true, 1000)]
    public static bool ValidateAddCustomEditor ()
    {
      var scriptAsset = Selection.activeObject;
      if (scriptAsset == null) {
        // nothing selected? (should probably not happen)
        return false;
      }
      var path = ProjectRoot + AssetDatabase.GetAssetPath (scriptAsset);
      if (!scriptPathRegex.IsMatch (path)) {
        // not a Script in the Script folder
        return false;
      }
      if (editorScriptPathRegex.IsMatch (path)) {
        // we are not interested in Editor scripts
        return false;
      }
        
      if (Directory.Exists (path)) {
        // it's a directory, but we want a file
        return false;
      }
      var scriptPathInfo = new ScriptPathInfo (scriptAsset);
      //		Debug.Log (scriptPathInfo.scriptPath);
      //		Debug.Log (Path.GetFullPath(AssetsPath + "/../"));
      //		Debug.Log (scriptPathInfo.editorRelativeAssetPath);
      //		Debug.Log (scriptPathInfo.editorPath);
      if (File.Exists (scriptPathInfo.editorPath)) {
        // editor has already been created
        return false;
      }
      // all good!
      return true;
    }
