    Bolt()
    {
        NotifyPropertyChanged(property)
        {
             PropertyChanged(this, property);
        }
    
        ChildNutPropertyChanged(Nut child, property)
        {
             PropertyChanged(this, child + property);
        }
    }
    
    
    Nut(Bolt parentBolt)
    { 
        parent = parentBolt;
        NotifyPropertyChanged(property)
        {
             PropertyChanged(this, property);
             parent.NotifyPropertyChanged(this, property);
        }
    }
