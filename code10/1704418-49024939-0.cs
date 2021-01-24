    using System;
    using AutoMapper;
					
	public class Program
	{
		public static void Main(string[] args)
        {
            var sVm = new SourceVM
            {
                cust_name = "Gaurav",
                appl_no = "HR99TEMP5253"
            };
            var r = MyConvert(sVm);
            Console.WriteLine(r.cust_name);
            Console.WriteLine(r.appl_no);
            Console.WriteLine(r.appl_date);
            r = MyConvert(null);
            Console.WriteLine(r.cust_name);
            Console.WriteLine(r.appl_no);
            Console.WriteLine(r.appl_date);
            
        }
        private static DestinationVM GetDest()
        {
            return new DestinationVM
            {
                cust_name = "Deepak",
                appl_no = "HR26DK6149",
				appl_date = DateTime.Now
            };
        }
        public static DestinationVM MyConvert(SourceVM vm)
        {            
            DestinationVM destVm = GetDest();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SourceVM, DestinationVM>()
                .ForAllMembers(opt => opt.Condition(src => src != null));
            });
            config.CreateMapper().Map(vm, destVm);
            return destVm;
        }
	}
	
	
	public class SourceVM
    {
        public string appl_no { get; set; }
        public string reff_number { get; set; }
        public string cust_name { get; set; }
        public string merchant_id { get; set; }
    }
    public class DestinationVM
    {
        public string appl_no { get; set; }
        public string reff_number { get; set; }
        public string cust_name { get; set; }
        public string merchant_id { get; set; }
        public Nullable<System.DateTime> appl_date { get; set; }
    }
