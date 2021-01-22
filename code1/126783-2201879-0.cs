    public void SerializeObject(this List<string> list, string fileName) {
      var serializer = new XmlSerializer(typeof(List<string>));
      using ( var stream = File.OpenWrite(fileName)) {
        serializer.Serialize(stream, list);
      }
    }
