    using System.Data.Linq.Mapping;
   
    public partial class MyEntity: IEntity 
     {    [Column(Storage="IDfield", DbType="int not null", IsPrimaryKey=true)]
          public int ID 
           {         
              get { return this.IDfield; }        
              set { this.IDfield=value;  }    
           } 
     }
