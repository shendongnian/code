      private void button1_Click(object sender, RoutedEventArgs e)
      {
         // Check if the event needs to be passed to button2's handler
         if (conditionIsMet)
         {
            // Send the event to button2
            button2.RaiseEvent(e);
         }
         else
         {
            // button1's "Click" code
         }
      }
      private void button2_Click(object sender, RoutedEventArgs e)
      {
         // button2's "Click" code
      }
