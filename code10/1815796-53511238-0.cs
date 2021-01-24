    public interface ITicketRepository
    {
        void ChangeAssignedAgent(ITicket ticket, string agentName);
        string GetAgentIDFromName(string agentName);
    }
