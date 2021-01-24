    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    
    namespace MyNamespace
    {
        public class BidModel
        {
            [JsonProperty("BudID")]
            public string BidId { get; set; }
            [JsonProperty("Summa")]
            public int Amount { get; set; }
            [JsonProperty("AuktionID")]
            public string AuctionId { get; set; }
            [JsonProperty("Budgivare")]
            public string Bidder { get; set; }
        }
    
        public class BidController : Controller
        {
            [HttpGet]
            public async Task<IActionResult> AddBid()
            {
                // For demo purposes - pre-fill some values
                var model = new BidModel
                {
                    Bidder = User.Identity.Name,
                    Amount = 123,
                    AuctionId = "A-ID",
                    BidId = "B-ID"
                };
    
                return View(model);
            }
    
            [HttpPost]
            public async Task<IActionResult> AddBid(BidModel Bid)
            {
                // save new bid
                // return RedirectToAction("ViewDetails", Bid.AuctionId);
    
                return View(Bid);
            }
        }
    }
