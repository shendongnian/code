    /*
     * This class represent a single item of your collection.
     * It has the same properties name than your JSON string members
     * You can use differents properties names, but you'll have to use attributes
     */
    class MyClass
    {
        public int VALUE { get; set; }
        public string ATTRIBUTE { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myJSON = "[{\"VALUE\":\"03\",\"ATTRIBUTE\":\"Laayelbxw\"},{\"VALUE\":\"01\",\"ATTRIBUTE\":\"Leruaret\"},{\"VALUE\":\"08\",\"ATTRIBUTE\":\"Lscwbryeiyabwaa\"},{\"VALUE\":\"09\",\"ATTRIBUTE\":\"Leruxyklrwbwaa\"}]";
            var MyCollection = JsonConvert.DeserializeObject<List<MyClass>>(myJSON);
            // Tadaam ! You now have a collection of MyClass objects created from that json string
        }
    }
