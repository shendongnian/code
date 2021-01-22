    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication
    {
        public partial class LabelEditor : Form
        {
            private System.Windows.Forms.TextBox textBox;
            public LabelEditor()
            {
                InitializeComponent();
                this.textBox = new System.Windows.Forms.TextBox();
                this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
                this.textBox.Location = new System.Drawing.Point(0, 0);
                this.textBox.Name = "textBox";
                this.textBox.Size = new System.Drawing.Size(100, 20);
                this.textBox.TabIndex = 0;
                this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
                this.AutoSize = true;
                this.ClientSize = new System.Drawing.Size(100, 20);
                this.Controls.Add(textBox);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.MinimumSize = new System.Drawing.Size(100, 20);
                this.Name = "LabelEditor";
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            }
            public override string Text
            {
                get
                {
                    if (textBox == null)
                        return String.Empty;
                    return textBox.Text;
                }
                set
                {
                    textBox.Text = value;
                    ResizeEditor();                
                }
            }
            private void ResizeEditor()
            {
                var size = TextRenderer.MeasureText(textBox.Text, textBox.Font);
                size.Width += 20;
                this.Size = size;
            }
            private void OnKeyDown(object sender, KeyEventArgs e)
            {
                switch (e.KeyData)
                {
                    case Keys.Escape:
                        DialogResult = DialogResult.Cancel;
                        this.Close();
                        break;
                    case Keys.Return:
                        DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                }
            }
        }
    }
