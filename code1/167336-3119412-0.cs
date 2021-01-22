    public partial class Form1 : Form
    {
        string[] Colors { get; set; }
        public Form1()
        {
            InitializeComponent();
            Colors = new string[] { "red", "blue", "white", "none", "orange" };
            listBox1.Items.AddRange(Colors);
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (Colors[e.Index] != "none")
            {
                using (var brush = new SolidBrush(Color.FromName(Colors[e.Index])))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
            }
            e.Graphics.DrawString(Colors[e.Index], Font, SystemBrushes.ControlText, e.Bounds);
        }
    }
