    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace SO887803
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.Run(new MainForm());
            }
        }
    
        public partial class MainForm : Form
        {
            private Button _Button;
            private ComboBox _ComboBox;
    
            public MainForm()
            {
                _Button = new Button();
                _Button.Text = "Test";
                _Button.Location = new Point(8, 8);
                _Button.Click += _Button_Click;
                Controls.Add(_Button);
    
                _ComboBox = new ComboBox();
                _ComboBox.Location = new Point(8, 40);
                Controls.Add(_ComboBox);
            }
    
            private void _Button_Click(object sender, EventArgs e)
            {
                List<Item> items = new List<Item>();
                items.Add(new Item("A", "a"));
                items.Add(new Item("B", "b"));
    
                _ComboBox.DataSource = null;
                _ComboBox.DataSource = items;
                _ComboBox.DisplayMember = "Title";
                _ComboBox.ValueMember = "Value";
                MessageBox.Show("count: " + _ComboBox.Items.Count);
            }
    
            public class Item
            {
                public String Title { get; set; }
                public String Value { get; set; }
                public Item(String title, String value)
                {
                    Title = title;
                    Value = value;
                }
            }
        }
    }
