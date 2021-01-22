    public class TemperatureTextBox : ContainerControl
    {
        private const int BORDER_SIZE = 1;
        // Exposes text property of text box,
        // expose other text box properties as needed:
        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
        private TextBox textBox = new TextBox()
        {
            Text = string.Empty,
            BorderStyle = BorderStyle.None,
            Dock = DockStyle.Fill
        };
        private Label label = new Label()
        {
            Text = "°C",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size()
            {
                Width = 32
            },
            BackColor = SystemColors.Window,
            Dock = DockStyle.Right
        };
        public TemperatureTextBox()
        {
            this.BackColor = SystemColors.Window;
            this.Padding = new Padding(BORDER_SIZE);
            this.Controls.Add(label);
            this.Controls.Add(textBox);
            this.PerformLayout();
        }
        // Constrain control size to textbox height plus top and bottom border:
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Height = (textBox.Height + (BORDER_SIZE * 2));
        }
        // Render a border around the control:
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(
                SystemPens.ControlDarkDark,
                new Rectangle()
                {
                    Width = (this.Width - BORDER_SIZE),
                    Height = (this.Height - BORDER_SIZE)
                });
        }
    }
