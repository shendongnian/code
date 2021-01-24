public class RandomViewModel
{
    public List<CustomerDto> Customers { get; set; }
    public List<ReportDto> Reports { get; set; }
}
[AllowAnonymous]
public ActionResult RandomView()
{
   // Customer.
   var customers = _context.Customers.ToList();
   List<CustomerDto> customersDto = new List<CustomerDto>();
   foreach (var customer in customers)
   {
      customersDto.Add(new CustomerDto() { 
      Id = customer.Id,
      Name = customer.Name
      });
   }
   // Reports.
   var Reports= _context.Reports.ToList();
   List<ReportsDto> reportsDto= new List<ReportsDto>();
   foreach (var report in reports)
   {
      reportsDto.Add(new ReportsDto() {
      Id = report.Id,
      Name = report.Name
      });
   }
   var randomViewModel = new RandomViewModel() {
      Customers = customersDto,
      Reports = reportsDto
   };
   return View(randomViewModel);
}
