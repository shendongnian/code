    public class TicketViewModel : Ticket {
         public string SomeOtherProperty { get; set; }
    
         public TicketViewModel(string ticketNumber, ..., string someOtherProperty)
              : base(ticketNumber, ....) 
         {
              this.SomeOtherProperty = someOtherProperty;
         }
    }
