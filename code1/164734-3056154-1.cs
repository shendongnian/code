     private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
            {
                ComboBox cb = (ComboBox)sender;
                int index = e.Index;
                Graphics g = e.Graphics;
    
                DataItem item = (DataItem)cb.Items[index];
    
                g.DrawString(item.Name, new Font("Arial", 8), new SolidBrush(Color.Blue), 0, e.Bounds.Y);
                g.DrawString(item.Age.ToString(), new Font("Arial", 8), new SolidBrush(Color.Blue), 100, e.Bounds.Y);
            }
    
            public class DataItem
            {
                public string Name;
                public int Age;
                public override string ToString()
                {
                    return string.Format("{0} {1}", Name, Age);
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                comboBox1.Items.Add(new DataItem { Name = "Apple", Age = 10 });
                comboBox1.Items.Add(new DataItem { Name = "Berry", Age = 20 });
                comboBox1.Items.Add(new DataItem { Name = "Cherry", Age = 30 });
            }
