        private VideoCapture m_videoCapture;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                m_videoCapture = new VideoCapture("controlcam.avi");
                Application.Idle += onProcessFrame;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void onProcessFrame(Object sender, EventArgs e)
        {
            Image<Bgr, Byte> frameImage = m_videoCapture.QueryFrame().ToImage<Bgr, Byte>();
            // Call your function or write your code here.
            DetectFaceHaar(frameImage);
        }
        private void DetectFaceHaar(Image<Bgr, byte> img)
        {
            try
            {
                string facePath = Path.GetFullPath(@"../../data/haarcascade_frontalface_default.xml");
                string eyePath = Path.GetFullPath(@"../../data/haarcascade_eye.xml");
                CascadeClassifier classifierFace = new CascadeClassifier(facePath);
                CascadeClassifier classifierEye = new CascadeClassifier(eyePath);
                var imgGray = img.Convert<Gray, byte>().Clone();
                Rectangle[] faces = classifierFace.DetectMultiScale(imgGray, 1.1, 4);
                foreach (var face in faces)
                {
                    img.Draw(face, new Bgr(0, 0, 255), 2);
                    imgGray.ROI = face;
                    Rectangle[] eyes = classifierEye.DetectMultiScale(imgGray, 1.1, 4);
                    foreach (var eye in eyes)
                    {
                        var e = eye;
                        e.X += face.X;
                        e.Y += face.Y;
                        img.Draw(e, new Bgr(0, 255, 0), 2);
                    }
                }
                pictureBox1.Image = img.Bitmap;
                pictureBox2.Image = img.Bitmap;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
