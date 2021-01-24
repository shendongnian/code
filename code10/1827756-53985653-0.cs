    Please follow the below:
    {"customer_number": "Cnum",
      "route_stops":[
             {"company": "My Company",
              "contact": { 
                    "name": "Fname Lname",
                    "phone": "0000000000"}}
                    ]}
    
     public class Order
        {
            public string customer_number;        
            public List<route_stops> route_stops;
        }
    
     public class route_stops
        {
            public string company;        
            public List<Contact> contact;
    
        }
    
    public class Contact
        {
             public string name;
            public string phone;
    
        }
