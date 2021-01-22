    public class CustomerBuilder
    {
       ......     
       public static implicit operator Customer( CustomerBuilder builder ) 
       {  
          return builder.Build();
       } 
    }
