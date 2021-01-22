      public class Order
      {
         private double _totalCash;
         private double _price;
         private double _quantity;
         private _IsDirtyTotalCash = true;
    
      private void CalcCashTotal()
      {
        _totalCash = _price * _quantity
      }
    
      public double Price
      {      
       set
       {
         _price = value;
         _IsDirtyTotalCash = true;
       }
      }
    
      public double Quantity
      {      
       set
       {
         _price = value;
         _IsDirtyTotalCash = true;
       }
      }
 
      public double TotalCash
      {      
       get
       {
        	if(_IsDirtyTotalCash)
    	{
      	  _totalCash = CalcTotalCost();
           _isDirtyTotalCash = false;
         }
         return _totalCash;
       }
      }
 	 
    }
