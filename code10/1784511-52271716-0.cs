                class DayButton : ContentView
            {
                public string EventDate;
                public string EventStartTime;
                public string EventEndTime;
                public string EventShift;
                public string EventName;
                public string EventDescription;
                public Grid insideGrid;
        
                public event EventHandler Clicked;
            
                private TapGestureRecognizer _buttonTap;
                private Lable _ButtonText;
            
                public DayButton()
                {
                    _ButtonText = new Lable 
                    { 
                          Text = EventName
                    }
                    insideGrid = new Grid
    		    {
    		        VerticalOptions = LayoutOptions.FillAndExpand,
    		        HorizontalOptions = LayoutOptions.FillAndExpand,
    		        RowSpacing = 0,
    
    		        RowDefinitions =
    		        {
    		            new RowDefinition {Height = GridLength.Auto} //0
    		        },
    		        ColumnDefinitions =
    		        {
    		            new ColumnDefinition {Width = GridLength.Star} //0
    		        }
    		    };
        
                   //Add your elements to the grid
                   insideGrid.Children.Add(_ButtonText, 0, 1, 0, 1)
    
                   //Set the grid as the content of this view
                   Content = insideGrid;
        
        
            
                    _buttonTap = new TapGestureRecognizer();
                    this.GestureRecognizers.Add(_buttonTap);
                    _buttonTap.Tapped += ButtonClicked;
                }
            }
        
                private async void ButtonClicked(object sender, EventArgs e)
                {
                    if (this.IsEnabled)
        	        {
        		        Clicked?.Invoke(this, e);
        	        }
                    
                }
