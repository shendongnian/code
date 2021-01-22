    Class Customer{
       int IDCustomer
       string CustomerName
       string CustomerAddress
       string CustomerCity
       List<Order> orders;
       public List<Order> SelectAll(){ return orders; }
    }
    
    Class Order{
       int IDOrder
       //int IDCustomer -not necessary as parent contains this info
       string SalePersonName
       decimal OrderSubTotal
       datetime OrderDateCreated
    }
