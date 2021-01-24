    public class DataService
    {
        public static void rentTruck(TruckRental toRent, bool isNewCustomer, TruckCustomer tcustomer)
        {
            using (var ctx = new DAD_TruckRental_RGMContext())
            {
    		   var ob =  ctx.TruckCustomer.Where(c => c.LicenseNumber   == customer.LicenseNumber);
               if ( ob != null) //not exist 
                {
                //create new here 
				ctx.TruckCustomer.Add(tcustomer);
            }
            
			//exist then just update State
            ctx.ob.State = EntityState.Modified;
			ctx.AddOrUpdate(ob);
            ctx.TruckRental.Add(toRent);
            ctx.SaveChanges();
        }
    }
