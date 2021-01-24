    public partial class Form1 : Form
    {
        private readonly Timer _imageTimer;
        private bool _firstClick;
        private PictureBox _firstPictureBoxClicked;
        private PictureBox _secondPictureBoxClicked;
        public Form1()
        {
            InitializeComponent();
            _firstClick = true;
            _imageTimer = new Timer(5000);
            _imageTimer.Elapsed += ImageTimerOnElapsed;
        }
        private void ImageTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            _imageTimer.Stop();
            _firstPictureBoxClicked.Invoke((MethodInvoker)delegate { _firstPictureBoxClicked.Visible = false; });
            _secondPictureBoxClicked.Invoke((MethodInvoker)delegate { _secondPictureBoxClicked.Visible = false; });
        }
        private void Picture_Click(object sender, EventArgs e)
        {
            if (_firstClick)
            {
                _firstPictureBoxClicked = (PictureBox) sender;
                ShowImage(_firstPictureBoxClicked);
            }
            else
            {
                if (((PictureBox) sender).Tag == _firstPictureBoxClicked.Tag)
                {
                    _secondPictureBoxClicked = (PictureBox)sender;
                    ShowImage(_secondPictureBoxClicked);
                    _imageTimer.Start();
                }
                else
                {
                    RemoveImage(_firstPictureBoxClicked);
                }
            }
            _firstClick = !_firstClick;
        }
        private void ShowImage(PictureBox pictureBox)
        {
            switch (pictureBox.Tag)
            {
                case "apple":
                    pictureBox.Image = Properties.Resources.apple;
                    break;
                case "banana":
                    pictureBox.Image = Properties.Resources.banana;
                    break;
            }
        }
        private void RemoveImage(PictureBox pictureBox)
        {
            pictureBox.Image = null;
        }
    }
