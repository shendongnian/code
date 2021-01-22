    public class Model : INotifyPropertyChanged {
    
    #region INotifyPropertyChanged implementation
       public event PropertyChangedEventHandler PropertyChanged;
       protected virtual void OnPropertyChanged(string propertyName) {
          var handler = PropertyChanged;
          if(null != handler)
             handler(this, new PropertyChangedEventArgs(propertyName));
    
          switch(propertyName){
             case Quantity:
             case UnitPrice:
                OnPropertyChanged("ExtendedPrice");
                break;
             case ExtendedPrice:
                OnPropertyChanged("Tax");
                OnPropertyChanged("GrandTotal");
                break;
             case Tax:
                OnPropertyChanged("GrandTotal");
                break;
          }
       }
    #endregion
    
       private int _quantity;
       public int Quantity{
          get { return _quantity; }
          set {
             if (value != _quantity) {
                _quantity = value;
                OnPropertyChanged("Quantity");
             }
          }
       }
    
       private decimal _unitPrice;
       public decimal UnitPrice {
          get { return _unitPrice; }
          set {
             if (value != _unitPrice) {
                _unitPrice = value;
                OnPropertyChanged("UnitPrice");
             }
          }
       }
    
       public decimal ExtendedPrice {
          get { return Quantity * UnitPrice; }
       }
    
       public decimal Tax {
          get { return ExtendedPrice * TaxRate; }
       }
    
       public decimal GrandTotal {
          get { return ExtendedPrice + Tax; }
       }
    }
