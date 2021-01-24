    //Variables
    string srvName;
    string mapSelect;
    string difSelect;
    int serverNumber = 0;
    ...
    
    serverNumber++;
    string filepath = Path.Combine(@"C:\Users\mlynch\Desktop\Test\Test", serverNumber.ToString(), ".txt");
    System.IO.File.WriteAllLines(filepath, lines);
