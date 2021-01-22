    public static Stream GetResourceFileStream(String nameSpace, String filePath)
    {
        String pseduoName = filePath.Replace('\\', '.');
        Assembly assembly = Assembly.GetExecutingAssembly();
        return assembly.GetManifestResourceStream(nameSpace + "." + pseduoName);
    }
