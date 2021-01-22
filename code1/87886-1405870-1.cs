      public enum Status { New, Edited, Approved, Cancelled, Closed }
      
      public class Order
      {
          private Status stat;
          public Status Status
          { 
             get { return stat; }
             set { stat = value; }
          }
      }
