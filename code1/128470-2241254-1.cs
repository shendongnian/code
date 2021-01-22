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
            int newStateId = TicketStateIds[ticket.State];
            // update Ticket table with newStateId
          }
        }
      }
    
      private Dictionary<TicketState, int> _ticketStateIds;
      protected Dictionary<TicketState, int> TicketStateIds{
        get {
          if (_ticketStateIds== null) 
            InitializeTicketStateIds();
          return _ticketStateIds;
        }
      }
      private void InitializeTicketStateIds() {
        // execute SQL to get all key-values pairs from TicketStateValues table
        // use hard-coded mapping from strings to enum to populate _ticketStateIds;
      }
    }
