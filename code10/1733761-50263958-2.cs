    using System;
    using System.Drawing;
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
                const int cols = 5;
                const int rows = 6;
    
                // setup layout
                var tlp = new TableLayoutPanel
                {
                    ColumnCount = cols,
                    RowCount = rows,
                    Dock = DockStyle.Fill,
                    GrowStyle = TableLayoutPanelGrowStyle.FixedSize
                };
    
                for (var i = 0; i < cols; i++)
                    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f / cols));
    
                // add header
                var label = new Label
                {
                    Text = @"My Header",
                    BackColor = Color.Red,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                tlp.Controls.Add(label);
                tlp.SetColumn(label, 0);
                tlp.SetRow(label, 0);
                tlp.SetColumnSpan(label, cols);
    
                // add some cells
                var yMin = 1;
                var yMax = 5;
                var xMin = 0;
                var xMax = cols;
                for (var y = yMin; y < yMax; y++)
                for (var x = xMin; x < xMax; x++)
                {
                    var color = Color.FromArgb(
                        255 / (xMax - xMin) * (x - xMin),
                        128,
                        255 / (yMax - yMin) * (y - yMin)
                    );
                    var label1 = new Label
                    {
                        Text = $@"X = {x}, Y = {y}",
                        BackColor = color,
                        ForeColor = Color.White,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Margin = DefaultMargin
                    };
                    tlp.Controls.Add(label1, x, y);
                }
    
                // add swapper
                var button = new Button
                {
                    Text = @"Clicky !",
                    Dock = DockStyle.Fill
                };
                button.Click += (o, args) =>
                {
                    var srcRow = 2;
                    var tgtRow = 3;
                    var controls = tlp.Controls.Cast<Control>().ToArray();
                    var array1 = controls.Where(s => tlp.GetRow(s) == srcRow).ToArray();
                    var array2 = controls.Where(s => tlp.GetRow(s) == tgtRow).ToArray();
    
                    foreach (var control in array1)
                        tlp.SetCellPosition(control, new TableLayoutPanelCellPosition(tlp.GetColumn(control), tgtRow));
    
                    foreach (var control in array2)
                        tlp.SetCellPosition(control, new TableLayoutPanelCellPosition(tlp.GetColumn(control), srcRow));
                };
    
                // pack things up
                var sc = new SplitContainer
                {
                    Orientation = Orientation.Horizontal,
                    BorderStyle = BorderStyle.Fixed3D,
                    Dock = DockStyle.Fill
                };
                sc.Panel1.Controls.Add(tlp);
                sc.Panel2.Controls.Add(button);
                Controls.Add(sc);
            }
        }
    }
