    public class RichPerson 
       {
          public string name {get; set;}
          [BsonRepresentation(MongoDB.Bson.BsonType.String)]
          public double money {get; set}
       }
