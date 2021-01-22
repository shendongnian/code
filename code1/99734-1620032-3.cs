    static void Main(string[] args)
    {
        InputFileHolder fileHolder = new InputFileHolder();
        fileHolder.InputFileList.Add(
            new ABCFile()
            {
                InputfileCommonProperty = "This is a common property",
                ABCSpecificProperty = "This is a class specific property"
            });
        XmlSerializer serializer = new XmlSerializer(typeof(InputFileHolder));
        MemoryStream memoryStream = new MemoryStream();
        serializer.Serialize(memoryStream, fileHolder);
        System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
        String serializedString = enc.GetString(memoryStream.ToArray());
    }
