    TicketRepository ticketRepository = new TicketRepository();
    
    public ActionResult List(int? page, int? pageSize)
    {
    	IPagination<hd_Ticket> tickets = null;
    	
    	int dPageSize = 50;
    	int totalItems;
    	
    	tickets = ticketRepository.GetTickets().ToList().AsPagination(page ?? 1, pageSize ?? dPageSize);
    	ViewData["totalItems"] = tickets.TotalItems;
    	
    	return View("List", tickets);
    }
