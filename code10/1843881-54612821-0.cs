    public partial class Form1 : Form {
        PictureBox pictureBox;
        public Form1() {
            InitializeComponent();
            AllowDrop = true;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
        }
