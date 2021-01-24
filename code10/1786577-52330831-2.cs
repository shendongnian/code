    var json = "";
    // MyObject o;
    using (FileStream s = File.Open(@"D:\test.json", FileMode.Open))
    using (StreamReader sr = new StreamReader(s))
    {
        json = sr.ReadToEnd();
    }
    var tmp = JsonConvert.DeserializeObject<Rootobject[]>(json);
    // don't forget to add using System.Linq;
    var dictionary = tmp.ToDictionary<string, string[]>(o => o.key, o => o.movies);
