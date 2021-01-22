    namespace Domain {
      public class Ticket {
        public Ticket() { State = TicketStates.New; }
        public void Finish() { State = TicketStates.Finished; }
        public TicketStates State {get;set;}
      }
    
      public enum TicketState { New, Finished }
    }
    
    namespace Repositories {
      public class SqlTicketRepository : ITicketRepository {
        public void Save(Ticket ticket) {
          using (var tx = new TransactionScope()) { // or whatever unit of work mechanism
            int newStateId = TicketStates[ticket.State];
            // update Ticket table with newStateId
          }
        }
      }
    
      private Dictionary<TicketState, int> _ticketStates;
      protected Dictionary<TicketState, int> TicketStates {
        get {
          if (_ticketStates == null) 
            InitializeTicketStates();
          return _ticketStates;
        }
      }
      private void InitializeTicketStates() {
        // execute SQL to get all key-values pairs from TicketStateValues
        // use hard-coded mapping from strings to enum to populate _ticketStates;
      }
    }
