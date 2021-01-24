    public class jsonPosSample
    {
       public Datafile dataFile { get; set; }
    }
    
    var result = JsonConvert.DeserializeObject<jsonPosSample>(strJSON);
