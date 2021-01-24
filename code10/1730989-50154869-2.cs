        [HttpPost]
        public WebResult Logout(string connectionId)
        {
            var cc = ConnectionManager.GetHubContext<EventsHub>();
            cc.Clients.Client(connectionId).TestLogoutCurrent();
        }
