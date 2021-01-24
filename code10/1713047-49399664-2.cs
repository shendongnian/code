    [DataContext]
    public abstract class BaseRequest
    {
      [DataMember]
      public virtual List<string> Fields { get; set; }
    }
    
    [DataContext]
    public class RequestWithDefault : BaseRequest
    {
      	[System.Runtime.Serialization.OnDeserialized]
        void OnDeserialized(System.Runtime.Serialization.StreamingContext c)
        {
          	if (Fields == null
          		|| Fields.Count < 1)
          	{
          		Fields = new List<string> { "test" };
          	}
        }
    }
