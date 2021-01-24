    chartMain.AxisY.Add(new Axis
    {
      MaxValue = 500,
      MinValue = 0,
      IsMerged = true,
      Position = AxisPosition.RightTop,
      ShowLabels = false,
      Sections = new SectionsCollection
      {
        new AxisSection
        {
          SectionWidth = m_TradeManager.Settings.RSIThreshold,
          Fill = new System.Windows.Media.SolidColorBrush
          {
            Color = System.Windows.Media.Color.FromRgb(254,132,132),
            Opacity = .4
          }
        }
      }
    });
