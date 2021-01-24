    private void hour_LostFocus(object sender, RoutedEventArgs e)
    {            
                string val = (sender as TextBox).Text;
                
                Regex regex = new Regex(@"^([0[0-9]|1[0-9]|2[0-3])$");
                Match match = regex.Match(val);
    
                if (!match.Success)
                {
                    //append 0 and other validations
                }            
    
    }
