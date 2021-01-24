        Button MyButton;
        if (Device.RuntimePlatform == Device.iOS)
        {
            MyButton = new Button
            {
                Margin = new Thickness(0, -15, 0, 0)                    
            };
        }
        else
        {
            MyButton = new Button
            {
                Margin = new Thickness(-10, -15, 0, 0)                   
            };
        }           
        var MyStackLayout = new StackLayout
        {
            Children = { MyButton }               
        };
