       public class MyFloorCollection : BindingList<Floor>
                {
                    public MyFloorCollection()
                        : base()
                    {
                        this.ListChanged += new ListChangedEventHandler(MyFloorCollection_ListChanged);
        
                    }
        
                    void MyFloorCollection_ListChanged(object sender, ListChangedEventArgs e)
                    {
                
                     if (e.ListChangedType == ListChangedType.ItemAdded)
                     {
      
                        Floor newFloor = this[e.NewIndex] as Floor;
        
                        if (newFloor != null)
                        {
                            newFloor.HeightChanged += new Floor.HeightChangedEventHandler(newFloor_HeightChanged);
                        }
                      }
        
                    }
                  
                    void newFloor_HeightChanged(int newValue, int oldValue)
                    {
                        //recaluclate
                    }
    
                   
                }
