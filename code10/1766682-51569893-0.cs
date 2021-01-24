    public partial class MainWindow : Window
    {
        public static Image<Bgr, Byte> contour_Frame;
        public Mini_Screen subwindow;
    
        public void MainWindow_Load(object sender, EventArgs e)
        {
            subwindow = new MiniScreen();
            subwindow.Show();
        }
    
        public void Bu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[Camera_ComboBox.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
        }
    
        void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Imgbox1.Image = skin;
            subwindow.DisplayImage = skin;
        }
    }
