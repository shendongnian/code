    using(var streamWriter = new StreamWriter("path\\toFile.csv")) 
    {
        streamWriter.WriteLine("ONE, TWO, THREE");
        foreach (var i in values)
        {
            fileData.DataOne = i["DataPointOne"].ToString();
            fileData.DataTwo = i["DataPointTwo"].ToString();
            fileData.DataThree = DateTime.Parse(i["DataPointThree"]);
            streamWriter.WriteLine(fileData.DataOne + "," + fileData.DataTwo + "," + fileData.DataThree);
        }
    }
