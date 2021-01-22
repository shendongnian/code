    public class MyOrderingClass : IComparer<Order> {  
        public int Compare(Order x, Order y) {  
            int compareDate = x.Date.CompareTo(y.Date);  
            if (compareDate == 0) {  
                int compareOrderId = x.OrderID.CompareTo(y.OrderID);  
                  
                if (OrderIdDescending) {  
                    compareOrderId = -compareOrderId;  
                }  
                return compareOrderId;  
            }  
              
            if (DateDescending) {  
                compareDate = -compareDate;  
            }  
            return compareDate;  
        }  
          
        public bool DateDescending { get; set; }  
        public bool OrderIdDescending { get; set; }  
    }  
	
