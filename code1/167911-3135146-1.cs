    public static readonly DependencyProperty CarProperty = 
            DependencyProperty.Register(  
                "CurrentCar",  
                typeof(Car),  
                typeof(CarIcon),  
                new UIPropertyMetadata(new Car())); 
