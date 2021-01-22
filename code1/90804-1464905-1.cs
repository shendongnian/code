    using (drOutput)   
    {
                System.Collections.Generic.List<CustomerEntity > arrObjects = new System.Collections.Generic.List<CustomerEntity >();        
                int customerId = drOutput.GetOrdinal("customerId ");
                int CustomerName = drOutput.GetOrdinal("CustomerName ");
            
            while (drOutput.Read())        
            {
                CustomerEntity obj=new CustomerEntity ();
                obj.customerId = (drOutput[customerId ] != Convert.DBNull) ? drOutput[customerId ].ToString() : null;
                obj.CustomerName = (drOutput[CustomerName ] != Convert.DBNull) ? drOutput[CustomerName ].ToString() : null;
                arrObjects .Add(obj);
            }
        
    }
