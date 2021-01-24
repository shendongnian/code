    using (var stream = File.Open("somefile", FileMode.CreateNew))
    {
        using (var sw = new StreamWriter(stream))
        {
            using (var jw = new JsonTextWriter(sw))
            {
                jw.WriteRaw("{}");
            }
        }
    }
