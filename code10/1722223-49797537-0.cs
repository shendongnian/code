    namespace DBEntity {
        public class Customer {
             public int Id { get; set; }  ...
        }
    }
    
    namespace BizEntity {
        public class Customer : INotifyPropertyChanged {
             private int id;
             public int Id { 
                      get { return this.id } ; 
                      set { 
                           this.id = value; 
                           PropertyChanged(Id...);
                           }
                      }
             NotifyPropertyChanged() {
                        ....
             }
    
    var dbCustomer = GetCustomerFromDB()
    var cust = AutoMapper.Mapper.Map<DBEntity.Customer, BizEntity.Customer>(dbCustomer);
    
    // Update the property as per biz requirement
    cust.Id = 53656;      // Fires the Notification
    
