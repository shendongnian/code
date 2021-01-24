     protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
                {
                    if (Element == null) 
                    {
                        return;
                    }
        
                    var entry = (CustomEntry)Element;
                    var textField = new CustomTextField();
                    textField.OnDeleteBackwardKey += (sender, a) =>
                    {
                        entry.OnBackButtonPress();
                    };
        
                    SetNativeControl(textField);
        
                    base.OnElementChanged(e);
                }
