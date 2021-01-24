        private void Button_Click(object sender, RoutedEventArgs e)
        {
         string textBoxValue = MessageTextBox.Text;
         if (string.IsNullOrWhiteSpace(textBoxValue))
         {
           // Display an error or warning message to ask user to enter some text.
            return;
         }
         else
         {
           foreach(char ch in textBoxValue)
           {
               // Now you have each character of the text entered in the textbox
               // You can write your logic now.
           }
         }
        }
