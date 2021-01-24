    public class Team 
    {
         [Key]
         public int Id {get;set;}
         public DivisionParticipant DivisionParticipant {get;set;}
    }
    
    public class DivisionParticipant
    {
         [Key, ForeignKey("Team")]
         public int Id {get;set;}
    
         public Team Team {get;set;}
    }
