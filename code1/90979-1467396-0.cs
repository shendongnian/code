    public class User
    {
       public virtual void Load(SqlDataReader reader)
       {
          this.Id = reader["Id"];
          //.. whatever else
       }
    }
    
    public class UserProfile : User
    {
       public string ExtraProp {get;set;}
       public override void Load(SqlDataReader reader)
       {
          base.Load(reader);
          this.ExtraProp = reader["ExtraProp"];
       }
    }
