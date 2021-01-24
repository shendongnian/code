    class myclass
    {
     public List<List<decimal>> foo { get; set; }
    }
    ….
    string str = "{ \"foo\": [[1.0, 2.0], [3.0, 4.0], [5.0, 6.0]] }";
    myclass my = JsonConvert.DeserializeObject<myclass>(str);
    string str2 = JsonConvert.SerializeObject(my);
