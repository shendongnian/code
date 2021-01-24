    var MyList = new List<string>();
    using (var streamReader = File.OpenText(pathToYourTextFile)) 
    {
        var s = string.Empty;
        while ((s = streamReader.ReadLine()) != null) 
           MyList.Add(s);
    } 
    myListbox.ItemsSource = MyList;
    
