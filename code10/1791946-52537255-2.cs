    using System.Diagnostics;
    
    namespace scrollviewerShyHeader
    {
        class ViewModel : ViewModelBase
        {
          
            public ViewModel()
            {
                ShyHeight = 100;
                ShyOpacity = 1.0;
                HeaderGridRow = 0;
                GridTopRowHeight = 100;
            }
    
    
            private int shyHeight;
            public int ShyHeight
            {
                get { return shyHeight; }
                set
                {
                    shyHeight = value;
                    RaisePropertyChanged();
                }
            }
    
            private double shyOpacity;
            public double ShyOpacity
            {
                get { return shyOpacity; }
                set
                {
                    shyOpacity = value;
                    RaisePropertyChanged();
                }
            }
    
    
            private double scrollerViewerOffset;
            public double ScrollViewerOffset
            {
                get { return scrollerViewerOffset; }
                set
                {
                    Debug.Print(value.ToString());
                    scrollerViewerOffset = value;
                    if (scrollerViewerOffset > 0)
                    {
                        ShyOpacity = 0.7;
                        ShyHeight = 80;
                        HeaderGridRow = 1;
                        GridTopRowHeight = 0;
                    } else if (scrollerViewerOffset == 0)
                    {
                        ShyOpacity = 1;
                        ShyHeight = 100;
                        HeaderGridRow = 0;
                        GridTopRowHeight = 100;
                    }
                }
            }
    
            private int headerGridRow;
            public int HeaderGridRow
            {
                get { return headerGridRow; }
                set
                {
                    headerGridRow = value;
                    RaisePropertyChanged();
                }
            }
    
            private int gridTopRowHeight;
    
            public int GridTopRowHeight
            {
                get { return gridTopRowHeight; }
                set { gridTopRowHeight = value; RaisePropertyChanged();}
            }
    
        }
    }
