    static void Main(string[] args)
    {
        Preferences preferences = null;
        var xmlString = Data.XML;
        using (var stream = new StringReader(xmlString))
        {
            var serializer = new XmlSerializer(typeof(Preferences));
            preferences = (Preferences)serializer.Deserialize(stream);
        }
        var node0 = new Font()
        {
            Fname = "New One",
            Role = "console",
            Size = "12"
        };
        var node1 = new Font()
        {
            Fname = "Helvetica",
            Role = "titles",
            Size = "10"
        };
        if (preferences.Font.Contains(node0))
        {
            // Not expecting to enter here
            Console.WriteLine($"'{nameof(node0)}' is already present");
        }
        if (preferences.Font.Contains(node1))
        {
            Console.WriteLine($"'{nameof(node1)}' is already present");
        }
    }
