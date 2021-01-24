    public class StockDataPanel : TabPage
    {
      // have Labels, RichTextBoxes, etc to display the data you need
    
      public string StockSymbol
      {
        set => _stockSymbolLabel.Text = value;
      }
      // etc for other data you need to give to the control to display
    }
