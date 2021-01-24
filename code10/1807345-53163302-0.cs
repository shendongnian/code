    string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myfile.csv");
    
    using (StreamWriter sw = File.CreateText(path))
    {
        for (int ndx = 0; ndx <= ArrayX.Length; ndx++)
        {
          sw.WriteLine(ArrayX[ndx] + "," + ArrayY[ndx]);
        }
    }
