    private List<DataPair> _datapair = new List<DataPair>();
    
    public void Append(DataPair pair)
    {
        _datapair.Add(pair);
    }
    
    public void FillFromFile(string filepath)
    {
        try
        {
            if (System.IO.File.Exists(filepath))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(filepath);
                string[] currentdata;
                while (sr.Peek() >= 0)
                {
                    currentdata = sr.ReadLine().Replace(',', '.').Trim().Split(';');
                    this.Append(new DataPair(currentdata[0],  System.Convert.ToSingle(currentdata[1])));
                }
    
                sr.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in datafile: {0}", e.ToString());
        }
    }
