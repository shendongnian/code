      /// <summary>
      /// Gets or sets the relative size of the top and bottom split window panes.
      /// </summary>
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      [UserScopedSetting]
      [DefaultSettingValue(".5")]
      public double SplitterDistancePercent
      {
         get { return (double)toplevelSplitContainer.SplitterDistance / toplevelSplitContainer.Size.Height; }
         set { toplevelSplitContainer.SplitterDistance = (int)((double)toplevelSplitContainer.Size.Height * value); }
      }
