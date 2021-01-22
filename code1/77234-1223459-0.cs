    public class Employee:INotifyPropertyChanged
        {
            public Employee(string Name_, string Designation_, DateTime BirthDate_)
            {
                this.Name = Name_;
                this.Designation = Designation_;
                this.BirthDate = BirthDate_;
            }
    
    
            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            #endregion
    
            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
    
            [DisplayName("Employee Name")]
            public string Name
            {
                get { return this._Name; }
    
                set
                {
                    if (value != this._Name)
                    {
                        this._Name = value;
                        NotifyPropertyChanged("Name");
                    }
                }
            }
            private string _Name = string.Empty;
    
            [DisplayName("Employee Designation")]
            public string Designation
            {
                get { return this._Designation; }
    
                set
                {
                    if (value != this._Designation)
                    {
                        this._Designation = value;
                        NotifyPropertyChanged("Designation");
                    }
                }
            }
            private string _Designation = string.Empty;
    
            public DateTime BirthDate
            {
                get { return this._BirthDate; }
    
                set
                {
                    if (value != this._BirthDate)
                    {
                        this._BirthDate = value;
                        NotifyPropertyChanged("BirthDate");
                    }
                }
            }
            private DateTime _BirthDate = DateTime.Today;
    
            [DisplayName("Age")]
            public int Age
            {
                get
                {
                    return DateTime.Today.Year - this.BirthDate.Year;
                }
            }
      }
