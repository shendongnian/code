        private void processFunction(object sender, EventArgs e) {
            Image<Bgr, Byte> frame = c0.QueryFrame();
            Image<Gray, Byte> grayscale = frame.Convert<Gray, Byte>();
            grayscale = grayscale.Canny(new Gray(0), new Gray(255)).Not(); //invert with Not()
            frame = frame.And(grayscale.Convert<Bgr, Byte>(), grayscale); //And function in action
            imageBox1.Image = frame;
            
        }
