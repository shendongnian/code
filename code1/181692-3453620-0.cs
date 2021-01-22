    public class Player
    {
       // methods that do interesting things here
       ...
    
       public string Name { get; set; }
    
       public PlayerDTO ToTransport()
       {
          return new PlayerDTO { Name = Name, ... };
       }
    }
    
    [DataContract]
    public class PlayerDTO
    {
       [DataMember]
       public string Name { get; set; }
    
       ...
    }
