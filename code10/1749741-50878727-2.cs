    private void OnAgeTextChanged(object sender, TextChangedEventArgs e)
    {
       var entry = (Entry)sender;
       entry.TextChanged -= OnAgeTextChanged;
        try
        { //[...] Your stuff
        }
        catch(Exception ex)
        {
            //[...] Your other stuff
        }
        finally{
              entry.TextChanged += OnAgeTextChanged;
        }
    }
