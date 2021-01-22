      using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Text;
      using System.ComponentModel;
      using System.Windows.Data;
      using System.Collections;
    
         namespace MySolution
         {
            public abstract class ObservableBase : INotifyPropertyChanged
            {
                public event PropertyChangedEventHandler PropertyChanged;
        
                public void RaisePropertyChanged(string propertyName)
                {
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
             }
         }
