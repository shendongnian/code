        public customer GetCustomer(int cID)
        {
           for (int x = 0; x < numCustomers; x++)
           {
              if (cList[x].getID() == cID)
              {
                 return cList[x];
              }
           }
           return null;
        }
  
