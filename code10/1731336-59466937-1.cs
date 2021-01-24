    //By following the below code, it help to accommodate the UI to fit into the All screen Resolution
    
           public TrkView()
                {
                    InitializeComponent();
                    Window MainWindow = System.Windows.Application.Current.MainWindow;
                    PresentationSource MainWindowPresentationSource = PresentationSource.FromVisual(MainWindow);
                    Matrix m = MainWindowPresentationSource.CompositionTarget.TransformToDevice;
                    var DpiWidthFactor = m.M11;
                    var DpiHeightFactor = m.M22;
                    double ScreenHeight = SystemParameters.PrimaryScreenHeight * DpiHeightFactor;
                    double ScreenWidth = SystemParameters.PrimaryScreenWidth * DpiWidthFactor;
                    this.trkSetWidthAdjust.Width = ScreenWidth - 240;//assigning the width for the panel
                    this.TrkAnalysisDataGrid.Height = ScreenHeight - 160;//assigning the Height for the DataGrid
                }
