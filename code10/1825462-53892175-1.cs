        private void FindAmount()
        {
            decimal totalSum = 0;
            //Add amounts of selected
            if (MyDTGRID.SelectedItems.Count > 0)
            {
                for (int i = 0; i <= dgDailyTransactions.SelectedItems.Count - 1; i++)
                {
                    Sales sales = dgDailyTransactions.SelectedItems[i] as Sales;
                    decimal amount = sales.Amount;
                    totalSum += amount;
                }
            }
            myTextBlock.Text = totalSum.ToString();
        }
