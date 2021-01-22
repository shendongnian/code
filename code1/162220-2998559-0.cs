    private static void ExtractAll(DirectoryInfo _workingFolder) {
        if(_workingFolder == null) {
            Console.WriteLine("Répertoire inexistant.");
            return;
        }
        foreach (DirectoryInfo subFolder in _workingFolder.GetDirectories("*", SearchOption.AllDirectories)) 
            foreach(FileInfo zippedFile in subFolder.GetFiles("*.zip", SearchOption.AllDirectories)) {
                if(zippedFile.Exists) {
                    Console.WriteLine(string.Format("Extraction du fichier : {0}", zippedFile.FullName));
                    Process task = new Process();
                    task.StartInfo.UseShellExecute = false;
                    task.StartInfo.FileName = @".\Tools\7za.exe";
                    task.StartInfo.Arguments = string.Format("x {0}", zippedFile.FullName);
                    task.StartInfo.CreateNoWindow = true;
                    task.Start();
                    Console.WriteLine(string.Format("Extraction de {0} terminée", zippedFile.FullName));
                    //ProcessStartInfo task = new ProcessStartInfo(@".\Tools\7za.exe", string.Format("x {0}", zippedFile.FullName));
                    //Process.Start(task);
                }
        }
    }
