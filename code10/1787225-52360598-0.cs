    public partial class Bubble : Form
    {
        private readonly double amountToFadeEachIteration;
        private readonly int fadeInterval = 100; 
        // Custom form constructor takes in all three required settings
        public Bubble(string displayText, int showTime, int fadeTime)
        {
            InitializeComponent();
            lblDisplay.AutoSize = true;
            lblDisplay.Text = displayText;
            lblDisplay.Left = ClientRectangle.Width / 2 - lblDisplay.Width / 2;
            lblDisplay.Top = ClientRectangle.Height / 2 - lblDisplay.Height / 2;
            showTimer.Interval = showTime;
            fadeTimer.Interval = fadeInterval;
            amountToFadeEachIteration = 1.0 / fadeTime * fadeInterval;
        }
        // The Shown event starts the first timer
        private void Bubble_Shown(object sender, EventArgs e)
        {
            showTimer.Start();
        }
        // The shownTimer starts the fadeTimer
        private void showTimer_Tick(object sender, EventArgs e)
        {
            showTimer.Stop();
            BackColor = Color.Red; // Just so we see when the fade starts
            fadeTimer.Start();
        }
        // The fade timer reduces opacity on each iteration until it's zero
        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            if (Opacity < 0) { Close(); }
            else { Opacity -= amountToFadeEachIteration; }
        }
    }
