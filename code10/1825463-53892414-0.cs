    private void dgDailyTransactions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Sales> myList=dgDailyTransactions.SelectedItems.Cast<Sales>();
            decimal totalSum = 0;
            if (myList.Count() > 0)
            {
                totalSum = myList.Sum(item => item.Amount);
            }
            myTextBlock.Text = totalSum.ToString();
        }
