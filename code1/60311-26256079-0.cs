        public static void ZipFolder(string sourceFolder, string zipFile)
        {
            if (!System.IO.Directory.Exists(sourceFolder))
                throw new ArgumentException("sourceDirectory");
            byte[] zipHeader = new byte[] { 80, 75, 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            using (System.IO.FileStream fs = System.IO.File.Create(zipFile))
            {
                fs.Write(zipHeader, 0, zipHeader.Length);
            }
            dynamic shellApplication = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
            dynamic source = shellApplication.NameSpace(sourceFolder);
            dynamic destination = shellApplication.NameSpace(zipFile);
            destination.CopyHere(source.Items(), 20);
        }
        public static void UnzipFile(string zipFile, string targetFolder)
        {
            if (!System.IO.Directory.Exists(targetFolder))
                System.IO.Directory.CreateDirectory(targetFolder);
            dynamic shellApplication = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
            dynamic compressedFolderContents = shellApplication.NameSpace(zipFile).Items;
            dynamic destinationFolder = shellApplication.NameSpace(targetFolder);
            destinationFolder.CopyHere(compressedFolderContents);
        }
    }
