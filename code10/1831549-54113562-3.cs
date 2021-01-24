    public class Model
    {
       public Model(int name, int tenantId)
       {
          Name = name;
          if(tenantId <= 0)
          {
              throw new Exception();
          }
          TenantId = tenantId;
       }
    
       public string Name { get; private set; }
       public int TenantId { get; private set; }
    }
