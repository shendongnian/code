    using (FileStream dll = File.OpenRead(path))
    {
       fileContent = new byte[dll.Length];
       dll.Read(fileContent, 0, (int)dll.Length);
    }
    Assembly assembly = appDomain.Load(fileContent);
