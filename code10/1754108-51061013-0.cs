    public abstract class RichPerson 
       {
          public string name;
          [BsonRepresentation(MongoDB.Bson.BsonType.String)]
          public BigInteger money;
       }
