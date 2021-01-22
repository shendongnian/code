    [System.Data.Services.IgnoreProperties("Status")]
    public class Order
    {
       public int ID {get; set;}
       public string Description {get; set;}
       public OrderStatus Status {get; set;}
       public int StatusValue
       {
          get
          {
               return (int)this.Status;
          }
          set
          {
              // Add validation here
              this.Status = (OrderStatus)value;
          } 
       }
    }
    
    public enum OrderStatus
    {
       New,
       InProcess,
       Complete
    }
