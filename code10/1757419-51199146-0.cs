    public class Company
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public List<Coupon> Coupons { get; set; }
            public Company()
            {
                Coupons = new List<Coupon>();
            }
        }
        public class Coupon
        {
            public bool IsUsed { get; set; }
            public double Amount { get; set; }
            public DateTime Date { get; set; }
        }
  
    public static class CouponManager
        {
            public const int MONTHS_BACK = 3;
           
            /// <summary>
            /// Returns all coupons within X months not used by the company
            /// </summary>
            /// <param name="c"></param>
            /// <returns></returns>
            public static List<Coupon> GetValidCoupons(Company c)
            {
                return c.Coupons.Where(
                    t => !t.IsUsed &&
                (Math.Abs((DateTime.Now.Month - t.Date.Month) + 12 * (DateTime.Now.Year - t.Date.Year))<   MONTHS_BACK))
                .OrderBy(t=>t.Date).ToList();
            }
            /// <summary>
            /// Find valid coupons, subtract from invoice each coupon amount until invoice is 0
            /// </summary>
            /// <param name="company"></param>
            /// <param name="invoice"></param>
            /// <returns></returns>
            public static double CalculateInvoice(Company company, double invoice)
            {
                double amountOwed = invoice;
                List<Coupon> coupons = GetValidCoupons(company);
                coupons.ForEach(c => {
                    if(invoice <= 0) //we are done with coupons
                        { return; }
                    if (c.Amount > invoice) //no credits to give
                    { return; }
                    invoice = invoice - c.Amount; //subtract amount from invoice
                    c.IsUsed = true; //mark coupon as used then update in db later
                });
                return invoice;
            }
            public static Company GetMockedCompany()
            {
                //mock data
                Company myCompany = new Company();
                bool used = false;
                for (int i = 0; i < 215; i++)
                {
                    Coupon c = new Coupon();
                    c.Date = DateTime.Now.AddDays(-i);
                    c.Amount = 5.00;
                    c.IsUsed = used;
                    used = !used;
                    myCompany.Coupons.Add(c);
                    Coupon d = new Coupon();
                    d.Date = DateTime.Now.AddDays(-i * 4);
                    d.Amount = 5.00;
                    d.IsUsed = used;
                    used = !used;
                    myCompany.Coupons.Add(d);
                }
                return myCompany;
            }
        }
