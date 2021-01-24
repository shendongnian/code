    var listOutput = new List<DatiOutput>();
    while ((line = file.ReadLine()) != null)
    {
    	var data = line.Split(new []{";"},StringSplitOptions.RemoveEmptyEntries);
    	if(!data[0].Trim().Equals("NAME"))
    		listOutput.Add(new DatiOutput{ Name = data[0].Trim(), City = data[1].Trim()});
    }
