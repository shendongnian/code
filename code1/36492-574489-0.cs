    string sXml = @"
    <root>
    <rosterlist>
        <roster>
            <userid>1</userid>
            <name>R1</name>
            <etc></etc>
        </roster>
        <roster>
            <userid>2</userid>
            <name>R2</name>
            <etc></etc>
        </roster>
    </rosterlist>
    <userlist>
        <user userid='1'>
            <name>User on roster</name>
        </user>
        <user userid='5'>
            <name>User not on roster</name>
        </user>
    </userlist>
    </root>
        
    ";
    
    XElement obRoot = XElement.Parse( sXml );
    var results = from user in obRoot.Elements("userlist").Elements("user")
       join roster in obRoot.Elements("rosterlist").Elements("roster")
       on user.Attribute("userid").Value equals roster.Element("userid").Value
       select new {Name=user.Element("name").Value, RosterName=roster.Element("name").Value} ;
    
    foreach (var v in results)
    {
       Console.WriteLine("{0, -20} on Roster {1, -20}", v.Name, v.RosterName);
    }
