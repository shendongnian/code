    public class Player
    {
       // methods that do interesting things here
       ...
    
       public string Name { get; set; }
    }
    
    [DataContract]
    public class PlayerDTO
    {
       [DataMember]
       public string Name { get; set; }
    
       ...
       public static explicit operator PlayerDTO(Player player)
       {
          return new PlayerDTO { Name = player.Name, ... };
       }
    }
