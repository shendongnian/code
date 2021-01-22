    public class TicketRepository
    {
    	private HelpDeskDataContext db = new HelpDeskDataContext();
    
    	public IQueryable<hd_Ticket> FindAllTickets()
    	{
    		return from ticket in db.hd_Tickets
    			   orderby ticket.CreatedDate descending
    			   select ticket;
    	}
    }
