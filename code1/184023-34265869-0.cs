    using (StreamReader reader = new StreamReader(fileName))
    {
    	string line; 
    	
    	while ((line = reader.ReadLine()) != null)
    	{
    		//Define pattern
    		Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            //Separating columns to array
    		string[] X = CSVParser.Split(line);
            /* Do something with X */
    	}
    }
