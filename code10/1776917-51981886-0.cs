        public class TimeHub: Hub
        {
        public async Task UpdateTime(string message)
        {
            if (Clients != null)
            {
                await Clients.All.SendAsync("ReceiveMessage", message);
            }
        }
        }
