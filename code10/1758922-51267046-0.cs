    private String _json { get; set; }
    
    public class Number
    {
        public string number { get; set; }
    }
    
    private void Serialize()
    {
        //Initialize  list object
        List<Number> list = new List<Number>();
        //add one item
        list.Add(new Number()
        {
            number = "795272334"
        });
        //Serialize list object into json string
        _json = JsonConvert.SerializeObject(list, Formatting.Indented);
    }
    
    private void Deserialize()
    {
        //initialize list object
        List<Number> list = new List<Number>();
        //deserealize json string into list object
        list = JsonConvert.DeserializeObject<List<Number>>(_json);
    }
