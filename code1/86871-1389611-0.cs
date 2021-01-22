     private void Form1_Load(object sender, EventArgs e)
            {
                listBox1.DrawMode = DrawMode.OwnerDrawVariable;
                listBox1.Items.Add("One");
                listBox1.Items.Add("Two");
                listBox1.Items.Add("Three");
                listBox1.DrawItem += new DrawItemEventHandler(listBox1_DrawItem);    
            }
    
            void listBox1_DrawItem(object sender, DrawItemEventArgs e)
            {
                ListBox l=sender as ListBox;
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawEllipse(Pens.Blue, new Rectangle(1, 1+e.Index * 15, 100, 10));
                e.Graphics.DrawString(l.Items[e.Index].ToString(), new Font(FontFamily.GenericSansSerif,9, FontStyle.Regular), Brushes.Red , e.Bounds);
            }
