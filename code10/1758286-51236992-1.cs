        public class InvoiceSale
        {
            public int Id { get; set; }
            public int BudgetId { get; set; }
            public int NumberInvoice { get; set; }
            public DateTime InvoiceSaleDate { get; set; }
            public Budget Budget { get; set; }
        }
        [HttpPost]
        public ActionResult CreateInvoiceSale(InvoiceSale newInvoiceSale)
        {
            var invoiceSale = new InvoiceSale
            {
                BudgetId = newInvoiceSale.BudgetId,
                NumberInvoice = newInvoiceSale.NumberInvoice,
                InvoiceSaleDate = newInvoiceSale.InvoiceSaleDate,
                //Here i need to pass the BudgetId value, but how can i do without a 
                //navigation property
            };
            _context.InvoiceSales.Add(invoiceSale);
            _context.SaveChanges();
            return Json("ok"):
        }
