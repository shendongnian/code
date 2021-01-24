    public class ServiceStatusHub : Hub {          
            public static void SetStatus(string message) {
                Clients.All.acknowledgeMessage(message);
            }
        }
