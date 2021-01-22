     Regex searchTerm = new Regex("^[a-eA-E]");
     var simpleListSource = (from item in doc.Descendants("item")
    where searchTerm.Matches(item.Element("title").Value).Count > 0
    orderby item.Element("title").Value
      select new
          {
            title = item.Element("title").Value,
            description = item.Element("description").Value,
            image = item.Element("image").Value,
            type = item.Element("type").Value,
            imagelink = item.Element("imagelink").Value
          }).ToList();
    rptGetItems.DataSource = simpleListSource;
    rptGetItems.DataBind();
         
    
                          
