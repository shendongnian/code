    private void Button_Click(object sender, RoutedEventArgs e)
      {
         stockName = "LUPIN";
         new Thread(() =>
            {
               RunStockParallel(stockName);
               Action action = new Action(SetTextBoxValues); // Maybe this is not required? But this was present in your original code, so I left it as is.
            }).Start();
      }
      public void RunStockParallel(string stockName)
      {
         var count = 0;
         do
         {
            HttpWebRequest stocks = null;
            try
            {
               //your logic will be here.. 
            }
            catch (Exception e)
            {
               //throw e;
            }
            //It will call the delegate method so that UI can update. 
            Action action = new Action(SetTextBoxValues);
            //Invoke the delegate
            action();
            //Increment the globally declared var stockname
            this.stockName = count++.ToString();
         } while (true);
      }
      private void SetTextBoxValues()
      {
         this.Dispatcher.Invoke(() =>
               {
                  this.text1.Text = stockName;
               });
      }
