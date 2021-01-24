    <RichTextBox Name="MyRichTextBox"/>
  
    public MainWindow()
    {
        InitializeComponent();
        var startPointer = MyRichTextBox.CaretPosition.DocumentStart;
        var endPointer = MyRichTextBox.CaretPosition.DocumentEnd;
    }
