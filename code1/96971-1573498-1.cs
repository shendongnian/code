    TextBlock tb = new TextBlock
                   {
                      Text = "This is some Green text up front.",
                      Foreground = Brushes.Green
                   };
    InlineCollection tbInlines = tb.Inlines;
    tbInlines.Add(new Run
                  {
                     Text = "This is some Blue text.",
                     TextWrapping = TextWrapping.Wrap,
                     Foreground = Brushes.Blue
                  });
    tbInlines.Add(new Run
                  {
                     Text = "This is some Green text following the Blue text."
                  });
    Run hyperlinkRun = new Run("And finally, this is a Hyperlink.");
    tbInlines.Add(new Hyperlink(hyperlinkRun));
