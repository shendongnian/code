    public class HttpClientTicketRepository : ITicketRepository
    {
        private readonly string _baseUrl;
        public HttpClientTicketRepository(string baseUrl)
        {
            if(string.IsNullOrEmpty(baseUrl))
                throw new ArgumentException($"{nameof(baseUrl)} cannot be null or empty.");
            _baseUrl = baseUrl;
        }
        public void ChangeAssignedAgent(ITicket ticket, string agentName)
        {
            var agentId = GetAgentIDFromName(agentName);
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(agentId, dataFormat:DataFormat.Json);
            request.AddJsonBody(ticket);
            client.Post(request);
        }
    }
