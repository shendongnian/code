    string path;
    int count = 0;
    int skip = 300;
    using (StreamReader sr = new StreamReader(path)) {
         while ((count < skip) && (sr.ReadLine() != null)) {
             count++;
         }
         if(!sr.EndOfStream)
             Console.WriteLine(sr.ReadLine());
         }
    }
