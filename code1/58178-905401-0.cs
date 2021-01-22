            //Load my xml document
            XDocument myData = XDocument.Load(PhysicalApplicationPath + "/Data.xml");
            
            //Create my new object
            HelpItem newitem = new HelpItem();
            newitem.Answer = answer;
            newitem.Question = question;
            newitem.Category = category;
            //Find the Parent Node and then add the new item to it.
            XElement helpItems = myData.Descendants("HelpItems").First();
            helpItems.Add(newitem.XmlHelpItem());
            //then save it back out to the file system
            myData.Save(PhysicalApplicationPath + "/Data.xml");
