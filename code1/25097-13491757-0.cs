    class ComboBoxReadOnly : ComboBox
    {
        public ComboBoxReadOnly()
        {
            textBox = new TextBox();
            textBox.ReadOnly = true;
            textBox.Visible = false;
        }
        private TextBox textBox;
        private bool readOnly = false;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                if (readOnly)
                {
                    this.Visible = false;
                    textBox.Text = this.Text;
                    textBox.Location = this.Location;
                    textBox.Size = this.Size;
                    textBox.Visible = true;
                    if (textBox.Parent == null)
                        this.Parent.Controls.Add(textBox);
                }
                else
                {
                    this.Visible = true;
                    this.textBox.Visible = false;
                }
            }
        }
    }
