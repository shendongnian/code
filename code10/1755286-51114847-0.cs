    public partial class Form1 : Form
    {
        private int prev = 0;
        private Point lblLocation = new Point(70, 100);
        private Point tbLocation = new Point(170, 100);
            
        public Form1()
        {
            InitializeComponent();
        }
    
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cur = Convert.ToInt32(comboBox1.SelectedItem);
            int tmp = cur - prev;
    
            if (tmp > 0)
            {
                // add new controls
                for (int i = 1; i <= tmp; i++)
                {
                    AddLabel(prev + i);
                    AddTextBox(prev + i);
                    lblLocation.Y += 30;
                    tbLocation.Y += 30;
                }
                prev = cur;
            }
            else
            {
                // remove controls
                tmp = Math.Abs(tmp);
                for(int i= 0; i < tmp; i++)
                {
                    RemoveControl($"lbl{prev}");
                    RemoveControl($"tb{prev}");
                    lblLocation.Y -= 30;
                    tbLocation.Y -= 30;
                    prev--;
                }
            }
        }
    
        private void AddLabel(int i)
        {
            new Label()
            {
                Name = $"lbl{i}",
                Text = $"lbl{i}",
    
                Location = lblLocation,
                Parent = this
            };
        }
    
        private void AddTextBox(int i)
        {
            new TextBox()
            {
                Name = $"tb{i}",
                Text = $"tb{i}",
    
                Location = tbLocation,
                Parent = this
            };
        }
    
        private void RemoveControl(string name)
        {
            foreach (Control item in Controls.OfType<Control>())
            {
                if (item.Name == name)
                {
                    Controls.Remove(item);
                }
            }
        }
    }
