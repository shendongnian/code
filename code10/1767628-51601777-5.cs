    using System.Timers;
    internal class DualTimer {
        
        #region Fields
        private Timer leftTimer;
        private Timer rightTimer;
        #endregion
        #region Events
        public event EventHandler LeftTick;
        public event EventHandler RightTick;
        #endregion
        #region Constructor(s)
        public DualTimer(int leftInterval, int rightInterval) {
            leftTimer = new Timer(leftInterval);
            rightTimer = new Timer(rightInterval);
            leftTimer.Elapsed += leftTimer_Elapsed;
            rightTimer.Elapsed += rightTimer_Elapsed;
        }
        #endregion
        #region Public Methods
        public void Start() {
            leftTimer.Start();
            rightTimer.Start();
        }
        public void Stop() {
            leftTimer.Stop();
            rightTimer.Stop();
        }
        #endregion
        #region Private Methods
        private void leftTimer_Elapsed(object sender, EventArgs e) {
            LeftTick(sender, e);
        }
        private void rightTimer_Elapsed(object sender, EventArgs e) {
            RightTick(sender, e);
        }
        #endregion
    }
