    void Main()
    {
	   var s = "{ \"Id\": 3355211, \"TimeStamp\": \"2018-08-13T00:16:06.47\", }";
	   JsonConvert.DeserializeObject<JsonClass>(s).Dump();
     }
    public class JsonClass{
	  public int Id { get; set; }
      public string TimeStamp { get; set; }
    }
