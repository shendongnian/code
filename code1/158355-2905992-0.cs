    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "Spring", "Summer", "Fall", "Winter" });
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            string folder = Application.StartupPath;
            string theme = (string)comboBox1.Items[comboBox1.SelectedIndex];
            string path = System.IO.Path.Combine(folder, theme + ".png");
            Image newImage = new Bitmap(path);
            if (this.BackgroundImage != null) this.BackgroundImage.Dispose();
            this.BackgroundImage = newImage;
        }
    }
