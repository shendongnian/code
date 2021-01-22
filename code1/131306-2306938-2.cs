       public class MyCoolClass : ISerializeAsCSV, IDisposable
       {
         
          protected static bool serializesToCSV = false;
    
          
          static MyCoolClass()
          {
             serializesToCSV = 
                (typeof(MyCoolClass).GetInterface("GrooveySoft.Shared.Interfaces.ISerializeAsCSV") == null)
                ? false
                : true;
    
          }
     
    
          public MyCoolClass(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
          {
            // your stuff here
          }
          
          public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
          {
             // your stuff here
          }
    
        }
