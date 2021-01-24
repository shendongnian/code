    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // some content
                var panel = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 5,
                    RowCount = 2
                };
    
                for (var y = 0; y < 2; y++)
                for (var x = 0; x < 5; x++)
                {
                    var control = new Button {Text = $@"X = {x}, Y = {y}"};
                    panel.Controls.Add(control, x, y);
                }
    
                // swap button
                var button = new Button
                {
                    Dock = DockStyle.Fill,
                    Text = @"Clicky !"
                };
    
                button.Click += (o, args) =>
                {
                    var dictionary = panel.Controls
                        .Cast<Control>()
                        .ToDictionary(k => k, v => panel.GetCellPosition(v));
    
                    foreach (var pair in dictionary)
                    {
                        var position = pair.Value;
                        position.Row ^= 1; // simple row swap
                        panel.SetCellPosition(pair.Key, position);
                    }
                };
    
                // add to form
                var container = new SplitContainer
                {
                    Dock = DockStyle.Fill,
                    Orientation = Orientation.Horizontal,
                    SplitterWidth = 5,
                    BorderStyle = BorderStyle.Fixed3D
                };
    
                container.Panel1.Controls.Add(panel);
                container.Panel2.Controls.Add(button);
    
                Controls.Add(container);
            }
        }
    }
