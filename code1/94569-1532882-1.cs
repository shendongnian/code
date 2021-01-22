    // create new XmlDocument and load file
    XmlDocument xdoc = new XmlDocument();
    xdoc.Load("YourFileName.xml");
    // find a <User> node with attribute ID=2
    XmlNode userNo2 = xdoc.SelectSingleNode("//User[@ID='2']");
    // if found, begin manipulation    
    if(userNo2 != null)
    {
       // find the <password> node for the user
       XmlNode password = userNo2.SelectSingleNode("password");
       if(password != null)
       {
          // change contents for <password> node 
          password.InnerText = "somthing that is different than before";
       }
    
       // find the <host> node for the user
       XmlNode hostNode = userNo2.SelectSingleNode("host");
       if(hostNode != null)
       {
          // change contents for <host> node 
          hostNode.InnerText = "the most current host that they were seen as";
       }
    
       // save changes to a new file (or the old one - up to you)
       xdoc.Save("YourFileNameNew.xml");
    }
