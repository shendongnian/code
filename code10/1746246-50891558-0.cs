    foreach (var item in cachedItems)
    {
        ///find the matching Uri to the repository you want
        if (item.RealmUri.AbsoluteUri == ...)
        {
            var type = item.GetType();
            var fields = type.GetFields();
            var filename = fields.First(x => x.Name == "_filename").GetValue(item);
            ///Now just need to parse the file
            using (var streamReader = new StreamReader(new FileStream(filename, FileMode.Open)))
            {
                while (streamReader.ReadLine() != "username") {}
                streamReader.ReadLine(); ///There is 1 garbage line after username before the actual username
                return streamReader.ReadLine();
            }
        }
    }
