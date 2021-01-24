     public class GameHub : Hub
    {
        public void Send(string move, int Id)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(move,Id);
        }
    }
   
