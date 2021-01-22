    string path = @"\\IP-Address\c$\info\filename.txt"
    if (File.Exists(path)){
        using (StreamReader sr = File.OpenText(path)){
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }
   }
