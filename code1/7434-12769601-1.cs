    try {
        string path = args[0];
        FileStream fh = new FileStream(path, FileMode.Open, FileAccess.Read);
        int i;
        string s = "";
        while ((i = fh.ReadByte()) != -1)
            s = s + (char)i;
         
        //its for reading number of paragraphs
        int count = 0;
        for (int j = 0; j < s.Length - 1; j++) {
                if (s.Substring(j, 1) == "\n")
                    count++;
        }
                
        Console.WriteLine("The total searches were :" + count);
                
        fh.Close();
            
    } catch(Exception ex) {
        Console.WriteLine(ex.Message);
    }         
     
   
