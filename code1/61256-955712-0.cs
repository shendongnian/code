    [DelimitedRecord(" ")]
    public sealed class HTTPRecord
    {
    
    public String IP;
    
    // Fields with prefix 'x' are useless to me... we omit those in processing later
    public String x1;
    [FieldDelimiter("[")]
    public String x2;
    
    
    [FieldDelimiter("]")]
    public String Timestamp;
    
    [FieldDelimiter("\"")]
    public String x3;
    
    public String Method;
    public String URL;
    
    [FieldDelimiter("\"")]
    public String Type;
    
    [FieldIgnored()]
    public String x4;
    	 
    [FieldDelimiter(" ")]
    public String x5;
    
    public int HTTPStatusCode;
    	 
    public long Bytes;
    	 
    [FieldQuoted()] 
    public String Referer;
    	 
    [FieldQuoted()] 
    public String UserAgent;
    }
