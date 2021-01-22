    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsFormsApplication
    {
        public partial class Form1 : Form
        {
            private Label EditableLabel;
            public Form1()
            {
                InitializeComponent();
                this.EditableLabel = new System.Windows.Forms.Label();
                this.EditableLabel.AutoSize = true;
                this.EditableLabel.Location = new System.Drawing.Point(102, 81);
                this.EditableLabel.Text = "Click me to change...";
                this.EditableLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LabelMouseDoubleClick);
                this.Controls.Add(this.EditableLabel);
            }
            private void LabelMouseDoubleClick(object sender, MouseEventArgs e)
            {
                var label = sender as Label;
                if (label != null)
                {
                    var editor = new LabelEditor();
                    editor.Location = label.PointToScreen(new Point(e.X + 5, e.Y + 5));
                    editor.Text = label.Text;
                    if (DialogResult.OK == editor.ShowDialog())
                    {
                        label.Text = editor.Text;
                    }
                }
            }
        }
    }
