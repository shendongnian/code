    public static Foo DeserializeFromFile(string sFilespec)
    {
            Xml.Serialization.XmlSerializer oSerializer = new Xml.Serialization.XmlSerializer(typeof(Foo));
            using (System.IO.FileStream oStream = new System.IO.FileStream(sFilespec, IO.FileMode.Open)) {
                return (Foo) oSerializer.Deserialize(oStream);
            }
    }
