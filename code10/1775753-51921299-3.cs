    var list = readData();
    
    WebsiteItemViewModel WebItem = new WebsiteItemViewModel
    {
    	Title = "Twitter Item",
    	Description = "Here is a long description that might be crossing the bounds but thats fine.",
    	Image = "../resources/twitter.png"
    };
    
    list.Add(WebItem);
    string resultJson2 = JsonConvert.SerializeObject(list);
    File.WriteAllText("Testfile", resultJson2);
