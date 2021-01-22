    interface displayableInOrderAndQuoteList {
       Date getDisplayDate();
    }
    
    public class Order {
       private Date orderDate;
    
       public Date getOrderDate() { //used only when treating object as an order
           return orderDate;
       }
    
       public Date getDisplayDate() {//used when displaying object via interface
           return orderDate;
       }
    }
    
    
    public class Quote {
       private Date quoteDate;
    
       public Date getQuoteDate() { //used only when treating object as a quote
           return quoteDate;
       }
    
       public Date getDisplayDate() {//used when displaying object via interface
           return quoteDate;
       }
    }
