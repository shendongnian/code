    public partial class Person
    {
      public int DepartmentId
      {
        get
        {
          if(this.DepartmentsReference.EntityKey == null) return 0;
          else 
            return (int)this.DepartmentsReference.EntityKey.EntityKeyValues[0].Value;
        }
        set
        {
          this.DepartmentsReference.EntityKey = 
              new EntityKey("YourEntities.DepartmentSet", "Id", value);
        }
      }
    }
