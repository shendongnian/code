    [FixedLengthRecord()] 
    public class MyData
    { 
      [FieldFixedLength(8)] 
      public string someData; 
      
      [FieldFixedLength(16)] 
      public int SomeNumber; 
    
      [FieldFixedLength(12)] 
      [FieldTrim(TrimMode.Right)]
      public string someMoreData;
    }
