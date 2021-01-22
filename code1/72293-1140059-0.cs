    public class MyFloorCollection : BindingList<Floor>
            {
                public MyFloorCollection()
                    : base()
                {
                    this.ListChanged += new ListChangedEventHandler(MyFloorCollection_ListChanged);
    
                }
    
                void MyFloorCollection_ListChanged(object sender, ListChangedEventArgs e)
                {
                    Floor newFloor = this[e.NewIndex] as Floor;
    
                    if (newFloor != null)
                    {
                        newFloor.PropertyChanged += new PropertyChangedEventHandler(newFloor_PropertyChanged);
                    }
    
                }
              
                void newFloor_PropertyChanged(object sender, PropertyChangedEventArgs e)
                {
                    if (e.PropertyName == "Height")
                    {
                        //recalculate elevation
                    }
                }
    
               
            }
     public class Floor : INotifyPropertyChanged
            {
                private int _height;
    
                public int Height
                {
                    get { return _height; }
                    set 
                    {
                        _height = value;
                        OnPropertyChanged("Height");
    
                    }
                }
    
    
    
    
                public int Elevation { get; set; }
    
                private void OnPropertyChanged(string property)
                {
                    if (this.PropertyChanged != null)
                        this.PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
    
                #region INotifyPropertyChanged Members
    
                public event PropertyChangedEventHandler PropertyChanged;
    
                #endregion
            }
