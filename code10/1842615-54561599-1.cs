    private void Button_Click(s, e)
    {
      foreach (string stock in stocks)
      {
        StockDataPanel panel = new StockDataPanel();
        panel.StockSymbol = "AMZN";
        panel.CurrentPrice = 387.98m;
        _tabControl.TabPages.Add(panel);
      }
    }
