    new MultiDataTrigger
    {
        Conditions = 
        {
            new Condition
                {
                    Binding = new Binding("IsDirty"),
                     Value = true
                },
            new Condition
            {                                                    
                Binding = new Binding("IsSelected"){RelativeSource = RelativeSource.Self},
                Value = true
            }
        },
    
        Setters =
        {
            new Setter
            {
                Property = Control.BackgroundProperty,
                 Value = Brushes.Pink,
            },
         }
    }
