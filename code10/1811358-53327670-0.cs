    public class SponsorInfo 
    {
        public int? ReferenceId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Relation { get; set; }
        public string Department { get; set; }
    }
    [HttpPost("customer", Name = "Submit Customer")]
    public IActionResult ActivateCustomer([FromBody]Customer customer)
    {
        //Do something with the Customer object.
        if (customer.sponsorInfo.ReferenceId == null || !customer.sponsorInfo.ReferenceId.HasValue)
        {
            //is SponsorB
        }
        else
        {
            //is SponsorA
        }
        return Ok();
    }
