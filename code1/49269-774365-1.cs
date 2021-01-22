    void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
            using (Image<Bgr, byte> frame = capture.QueryFrame())
            {
                    if (frame != null)
                    {
                            var bmp = frame.AsImageSource();
                    }
            }
    }
