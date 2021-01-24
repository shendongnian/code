    #line hidden
    public static class MyDebugClass
    {
      public static Object LoadAssetAtPath(string assetPath, Type type)
      {
        Debug.Log("LoadAssetAtPath called");
        return AssetDatabase.LoadAssetAtPath(assetPath, type);
      }
    }
    #line default
