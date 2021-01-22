    StreamReader streamReader = new StreamReader("C:\\Text.txt");
    ArrayList lines = new ArrayList();
    
    string t =streamReader.ReadToEnd() ;
    
    streamReader.Close();
    Console.Write((t.Substring(t.LastIndexOf(System.Environment.NewLine))));
    Console.ReadKey(); 
