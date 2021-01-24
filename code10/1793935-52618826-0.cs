       public async void USBDriveCopyFolder()
        {
            var targetFolderName = "test";
            var removableDevice = (await KnownFolders.RemovableDevices.GetFoldersAsync()).FirstOrDefault();
            if (null == removableDevice)
            {
                System.Diagnostics.Debug.WriteLine("removableDevice is null !");
                return;
            }
            System.Diagnostics.Debug.WriteLine(removableDevice.Name + ":\n");
            var sourceFolder = await removableDevice.GetFolderAsync(targetFolderName);
            if (null == sourceFolder)
            {
                System.Diagnostics.Debug.WriteLine(targetFolderName + " folder is not found !");
                return;
            }
            System.Diagnostics.Debug.WriteLine(sourceFolder.Name + ":\n");
            var destFodler = KnownFolders.DocumentsLibrary;
            if (null == destFodler)
            {
                System.Diagnostics.Debug.WriteLine("KnownFolders.DocumentsLibrary folder get failed !");
                return;
            }
            var files = await sourceFolder.GetFilesAsync();
            foreach (var file in files)
            {
                System.Diagnostics.Debug.WriteLine(file.Name + "\n");
                await file.CopyAsync(destFodler);
            }
        }
