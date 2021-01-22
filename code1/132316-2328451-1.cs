    public DataTable ParseCSVFile(string path) {
    
      string inputString="";
    
      // check that the file exists before opening it
      if (File.Exists(path)) {
      
        StreamReader sr = new StreamReader(path);
        inputString = sr.ReadToEnd();
        sr.Close();
        
      }
      
      return ParseCSV(inputString);
    }
