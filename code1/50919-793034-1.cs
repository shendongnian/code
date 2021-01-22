    string xmlSource = "<ResultSet><Result precision=\"address\"><Latitude>47.643727</Latitude></Result></ResultSet>";
    
    var serializer = new XmlSerializer(typeof(ResultSet));
    ResultSet output;
    
    using (var reader = new StringReader(xmlSource))
    {
        output = (ResultSet)serializer.Deserialize(reader);
    }
