    class MyData
    {
    	public int id { get; set; }
    	public string name { get; set; }
    	public bool selected { get; set; }
    	public List<MySubData> lstSubData { get; set; }
    }
    
    class MySubData
    {
    	public string LED;
    	public string Servo;
    }
