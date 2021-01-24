    private double GetHeight()
    {
       double height = 0;
       foreach (var item in rootStackPanel.Children as IEnumerable)
       {
          if (item is TextBox tb)
          {
             tb.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
             height += tb.DesiredSize.Height;
          }
       }
       return height;
    }
