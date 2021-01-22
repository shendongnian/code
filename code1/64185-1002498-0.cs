    public class InnerClass: INotifyPropertyChanged
    {
         private string _propertyName;
         //Implemented from INotifyPropertyChanged
         public event PropertyChangedEventHandler PropertyChanged;
         
         public string PropertyName
         {
            get { return _propertyName; }
            set 
            { 
                  _propertyName = value;
                  OnPropertyChanged("Name or Property Data"); 
            }
         }
         //Just using string as an example, send whatever data you'd like
         protected void PropertyChanged(string name)
         {
            //Check to make sure the event is wired.
            if(PropertyChanged != null)
            {
                  //Fire event
                  PropertyChanged(this, name);
            }
         }
    }
