    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    
    namespace Testing
    {
    	public class TestController : Controller
        {
            public IActionResult Index()
            {
    			// Get Products from database
    			Product[] products = new Product[]
    			{
    				new Product { ProductId = 1, Name = "Item 1" },
    				new Product { ProductId = 2, Name = "Item 2" },
    				new Product { ProductId = 3, Name = "Item 3" }
    			};
    
    			// Create your TicketModel from Ticket and Products in here
    			TicketModel model = new TicketModel
    			{
    				Ticket = new Ticket() { TicketId = 1 },
    				AvailableProducts = products.Select(x => new SelectListItem { Value = x.ProductId.ToString(), Text = x.Name })
    			};
    
    			return View(model);
            }
    
    		[HttpPost]
    		[ValidateAntiForgeryToken]
    		public IActionResult Index(TicketModel model)
    		{
    			if (ModelState.IsValid)
    			{
    				// Create your Ticket from TicketModel in here
    			}
    			else
    			{
    				// In case of errors recreate AvailableProducts
    			}
    
    			return View(model);
    		}
    	}
    }
