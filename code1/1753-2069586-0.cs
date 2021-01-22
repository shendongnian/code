    public partial class MyEntity: IEntity 
     {    [Column(Name = "IDfield", Storage = "_IDfield", IsDbGenerated = true)]
          public int ID 
           {         
              get { return this.IDfield; }        
              set { this.IDfield=value;  }    
           } 
     }
