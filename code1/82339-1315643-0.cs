    public interface IPerson {
      string PersonClassification { get; set; }
      DateTime CreateDate { get; set; }
     }
    
    public class Person :  IPerson {
      public string PersonClassification { get; set; }
      public DateTime CreateDate { get; set; }
     }
    
    
    
    
    public class TransformerBase<T> 
     where T : IPerson {
    
    	T Person { get; set; }
    
    	T Transform(Func<T, PersonClassification> transformer) {
    		return transformer(person);
    	}
    }
    
    
    public class  OfflinePersonToOnlineTransformation : TransformerBase<Person>
    {
       public OfflinePersonToOnlineTransformation()
       {
            Transform(x => x.PersonClassification)
               .WhenCreatedBefore("1/1/2000")
               .ClassifyAs("Online");
       }
    }
    
    public static class Extensions {
    
    	public static T WhenCreatedBefore<T>(this T person, string date) where T : IPerson{
    		if(person == null || person.CreateDate > DateTime.Parse(date)) 
    			return null
    		return person;	
    	}
    	public static T Classify<T>(this T person, string classification)where T : IPerson{
    		if(person != null) 
    			person.PersonClassification = classification;
    		return person;	
    	}
    }
