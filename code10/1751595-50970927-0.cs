    public class ChatHub : Hub
    {
        public void Login(string login)
        {
            Context.Items["Login"] = login;
        }
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync(Context.Items["Login"] + "sends the message : " + message);
        }
    }
