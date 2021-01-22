        var doc = XDocument.Load("tree.xml");
        
        //Declare the delegate for using it recursively
        Func<int?, IEnumerable<Competition>> selectCompetitions = null;
    
        selectCompetitions = (int? id) =>
        {
           return doc.Elements("Competitions").Elements().Where(c => 
           {
             //If id is null return only root nodes (without ParentCompetitionID attribute)
             if (id == null)
                return c.Attribute("ParentCompetitionID") == null;
             else
                //If id has value, look for nodes with that parent id
                return  c.Attribute("ParentCompetitionID") != null &&
                        c.Attribute("ParentCompetitionID").Value == id.Value.ToString();
            }).Select(x => new Competition() 
                           { 
                          CompetitionID = Convert.ToInt32(x.Attribute("ID").Value),
                          //Always look for childs with this node id, call again to this
                          //delegate with the corresponding ID
                          Childs = selectCompetitions(Convert.ToInt32(x.Attribute("ID").Value))
                           });
    };
       
    var competitions = selectCompetitions(null);
  
