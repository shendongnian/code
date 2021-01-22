    using (var stream = new FileStream(@"c:\temp\file.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
       using (var file = new StreamReader(stream)) {
          while (!file.EndOfStream) {
             var line = file.ReadLine();
             Console.WriteLine(line);
          }
       }
    }
