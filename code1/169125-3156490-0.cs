    public class MyObject
    {
        // Properties to hold column data
        public string Column1 { get; set; }
        public string Column2 { get; set; }
    }
...
    public List<MyObject> parseCSV(string path)
    {
        List<MyObject> parsedData = new List<MyObject>();
        try
        {
            using (StreamReader readfile = new StreamReader(path))
            {
                string line;
                string[] row;
                while ((line = readfile.ReadLine()) != null)
                {
                    row = line.Split('\t');
                    
                    // Here we assume we know the order of the columns in the TSV
                    // And we populate the object
                    MyObject myObject = new MyObject();
                    myObject.Column1 = row[0];
                    myObject.Column2 = row[1];
                    parsedData.Add(myObject);
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        return parsedData;
    }
