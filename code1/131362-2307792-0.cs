    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        byte interpolate(byte a, byte b, double p)
        {
            return (byte)(a * (1 - p) + b * p);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int v = trackBar1.Value;
            BackColor = getColor(v);
        }
        private Color getColor(int v)
        {
            SortedDictionary<int, Color> d = new SortedDictionary<int, Color>();
            d.Add(0, Color.Blue);
            d.Add(100, Color.Green);
            d.Add(200, Color.Orange);
            d.Add(300, Color.Yellow);
            d.Add(400, Color.Red);
            
            KeyValuePair<int, Color> kvp_previous = new KeyValuePair<int,Color>(-1, Color.Black);
            foreach (KeyValuePair<int, Color> kvp in d)
            {
                if (kvp.Key > v)
                {
                    double p = (v - kvp_previous.Key) / (double)(kvp.Key - kvp_previous.Key);
                    Color a = kvp_previous.Value;
                    Color b = kvp.Value;
                    Color c = Color.FromArgb(
                        interpolate(a.R, b.R, p),
                        interpolate(a.G, b.G, p),
                        interpolate(a.B, b.B, p));
                    return c;
                }
                kvp_previous = kvp;
            }
            return Color.Black;
        }
    }
