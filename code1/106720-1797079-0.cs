        static System.Windows.Forms.Timer _Timer = new System.Windows.Forms.Timer(); 
        int _Stop = 0;
        private void This_Loaded(object sender, RoutedEventArgs e)
        {
            _Timer.Tick += new EventHandler(timer_Tick);
            _Timer.Interval = (20); 
            resize(500,500)
        }
        private void timer_Tick(Object myObject, EventArgs myEventArgs)
        {
            if (_Stop == 0)
            {
                _RatioHeight    = ((this.Height -   _Height)    / 12)* -1;
                _RatioWidth     = ((this.Width -    _Width)     / 12)* -1;
            }
            _Stop++;
            this.Height += _RatioHeight;
            this.Width  += _RatioWidth;
            if (_Stop == 12)
            {
                _Timer.Stop();
                _Timer.Enabled = false;
                _Timer.Dispose();
                _Stop = 0;
                this.Height = _Height;
                this.Width  = _Width;
            }
        }
        public void resize(double _PassedHeight, double _PassedWidth)
        {
            _Height = _PassedHeight;
            _Width  = _PassedWidth;
            _Timer.Enabled = true;
            _Timer.Start();
        }
