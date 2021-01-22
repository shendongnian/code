    <ListView x:Name="MyListView"IsSynchronizedWithCurrentItem="True" 
                ItemsSource="{Binding Path=Items}",  Mode=Default, 
                Source={StaticResource DataProvider}}"  
                Thumb.DragDelta="Thumb_DragDelta">
  
    public Window1()
    { 
      InitializeComponent();  
      MyListView.AddHandler(Thumb.DragDeltaEvent,
                      new DragDeltaEventHandler(Thumb_DragDelta),
                      true );
    void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
       Thumb senderAsThumb = e.OriginalSource as Thumb;  
       GridViewColumnHeader header = senderAsThumb.TemplatedParent as GridViewColumnHeader;    
       if (header.Column.ActualWidth < MIN_WIDTH) 
       { 
         header.Column.Width = MIN_WIDTH;
       }
       if (header.Column.ActualWidth > MAX_WIDTH)  
       {
          header.Column.Width = MAX_WIDTH;   
       }
    }
    }
