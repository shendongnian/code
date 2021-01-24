    listBox1.Items.Add("Item1");
    listBox1.Items.Add("Item2");
    
     using (TextWriter txt = new StreamWriter("IP.txt"))
     {
         foreach (var item in listBox1.Items)
         {
             txt.WriteLine(item.ToString());
         }
     }
    
     listBox1.Items.Clear();
    
     using (StreamReader inputFile = File.OpenText("IP.txt"))
     {
         while (!inputFile.EndOfStream)
         {
             listBox1.Items.Add(inputFile.ReadLine() + " text from file");
         }
     }
