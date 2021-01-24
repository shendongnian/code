    VideoCapture capture;
    Mat frame;
    Bitmap image;
    private Thread camera;
    int isCameraRunning = 0;
    private void CaptureCamera() {
        camera = new Thread(new ThreadStart(CaptureCameraCallback));
        camera.Start();
    }
    ImageFilter IF;
    private void CaptureCameraCallback() {
        IF = new ImageFilter();
        frame = new Mat();
        capture = new VideoCapture(0);
        capture.Open(0);
        if (capture.IsOpened()) {
            while (isCameraRunning == 1) {
                BitmapEx Stable = IF.GetStable();
                if (Stable != null) {
                    if (pictureBox2.Image != null) {
                        pictureBox2.Image.Dispose();
                    }
                    pictureBox2.Image = Stable.GetDirectBmp();
                }
                capture.Read(frame);
                image = BitmapConverter.ToBitmap(frame);
                if (pictureBox1.Image != null) {
                    pictureBox1.Image.Dispose();
                }
                BitmapEx bmp = new BitmapEx(image);
                pictureBox1.Image = bmp.GetDirectBmp();
                IF.Process(bmp);
                if (pictureBox3.Image != null) {
                    pictureBox3.Image.Dispose();
                }
                pictureBox3.Image = IF.Mask(bmp);
            }
        }
    }
    private void button1_Click(object sender, EventArgs e) {
        if (button1.Text.Equals("Start")) {
            CaptureCamera();
            button1.Text = "Stop";
            isCameraRunning = 1;
        }
        else {
            capture.Release();
            button1.Text = "Start";
            isCameraRunning = 0;
        }
    }
