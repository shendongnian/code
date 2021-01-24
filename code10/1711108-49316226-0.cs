    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    
    namespace Testing
    {
    	public class Ticket
    	{
    		public int TicketId { get; set; }
    		public Product Product { get; set; }
    	}
    
    	public class Product
    	{
    		public int ProductId { get; set; }
    		public string Name { get; set; }
    	}
    
    	public class TicketModel
    	{
    		public string ProductId { get; set; }
    		public Ticket Ticket { get; set; }
    		public IEnumerable<SelectListItem> AvailableProducts { get; set; }
    	}
    }
