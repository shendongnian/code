    private void UserCalcSomething_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() => {
           double s = 0;
           for (int i = 0; i < 100000; i++)
           {
               for (int j = 0; j < 10000; j++)
               {
                   s = i + j;
               }
           }
        }
    }
