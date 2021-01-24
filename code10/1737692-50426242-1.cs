    var xs = new XmlSerializer(typeof(GeneralInformation));
    using (var writer = new CustomWriter(Console.Out))
    {
        writer.Formatting = Formatting.Indented;
        xs.Serialize(writer, data);
    }
