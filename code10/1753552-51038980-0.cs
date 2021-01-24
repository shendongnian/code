    JavaScriptSerializer js = new JavaScriptSerializer();  
    BlogSites blogObject = js.Deserialize<BlogSites>(jsonData);  
    string name = blogObject.Name;  
    string description = blogObject.Description;  
      
    // Other way to whithout help of BlogSites class  
    dynamic blogObject = js.Deserialize<dynamic>(jsonData);  
    string name = blogObject["Name"];  
    string description = blogObject["Description"];  
