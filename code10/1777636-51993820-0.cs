    List<List<string>> data = new List<List<string>>();
    var list = new List<string>();
    var regex = new Regex(@"(Grid-ref)");
    using (var sr = new StreamReader("cru-ts-2-10.1991-2000-cutdown.pre"))
    {
        string line;
        while((line = sr.ReadLine()) != null)
        {
            list.Add(line);
        }
    
        for(int i = 0; i < list.Count; i++)
        {
            if (regex.IsMatch(list[i])) //line matches "Grid=ref"
            {
                List<string> data_block = new List<string>(); //data_block is for the 10 lines
                data.Add(data_block); //add data_block list to bigger 2D list
            }
            else //other data
            {
                data[data.Count].Add(list[i]); //put other data into the most recent list
            }
        }
    }
