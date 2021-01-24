     // Removed the IDisposable interface
     public interface IDeliveryRepository
     {
         IEnumerable<Delivery> GetDeliveries();
     
         // Changed the below from a Task to a Delivery as the return type. To use Task, 
         // your entire implementation should be asynchronous.
         Delivery GetDelivery(int id);
         void Insert(Delivery delivery);
         void Delete(Delivery delivery);
         void Update(Delivery delivery);
     }
    
     public class DeliveryRepository: IDeliveryRepository
     {
         public Delivery GetDelivery(int id)
         {
             Delivery delivery = null;
             var sql = "SELECT d.id , o.owner_id, o.name FROM delivery d JOIN owner o on o.id = d.owner_id where id = :t";
             using (var con = new OracleConnection(AppConfig.CALL_CENTER_CONNECTION_STRING))
             {
                 con.Open();
                 using (var cmd = new OracleCommand(sql, con))
                 {
                     cmd.BindByName = true;
                     cmd.Parameters.Add("t", id);
                     using (var oraReader = cmd.ExecuteReader())
                     {
                         while (oraReader.Read())
                         {
                             delivery = new Delivery
                             {
                                 Id = oraReader.GetString(oraReader.GetOrdinal("id")),
                                 Owner = new Owner
                                    {
                                     Id = oraReader.GetString(oraReader.GetOrdinal("owner_id")),
                                     Name = oraReader.GetString(oraReader.GetOrdinal("name"))
                                 }
                             };
                         }
                     }
                 }
             }
             return delivery;
         }
    
       public void Insert(Delivery delivery)
       {
           /// Add your code here 
           throw new NotImplementedException();
       }
    
    
       public void Delete(Delivery delivery);
       {
           /// Add your code here 
           throw new NotImplementedException();
       }
    
       public void Update(Delivery delivery);
       {
           /// Add your code here 
           throw new NotImplementedException();
        }
        public IEnumerable<Delivery> GetDeliveries();
        {
           /// Add your code here 
           throw new NotImplementedException();
        }
    }
