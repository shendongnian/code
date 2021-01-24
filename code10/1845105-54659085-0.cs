    private void btnEnter_Click(object sender, RoutedEventArgs e)
        {   
            //this will check if the text from the box can be parsed as an integer then
            //exit this method but show message box with your message.      
            if(int.TryParse(txtInfo.Text, out var test)
             {
                 MessageBox.Show("Integers are not allowed");
                 return; 
              }
                string[] words = { txtInfo.Text };
    
                foreach (string f in words)
                {
                    lstResults.Items.Add(f);
                }
                txtInfo.Text = "";  
            
        }
