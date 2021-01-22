    static void serializer_UnknownElement(object sender, XmlElementEventArgs e)
    {
        if( e.Element.Name != "Hobbies")
        {
            return;
        }
     
        var target = (MyData) e.ObjectBeingDeserialized;
        foreach(XmlElement hobby in e.Element.ChildNodes)
        {
            target.Hobbies.Add(hobby.InnerText);
            target.HobbyData.Add(new Hobby{Name = hobby.InnerText});
        }
    }
