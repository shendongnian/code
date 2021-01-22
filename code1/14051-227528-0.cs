            this.textBox1.SizeChanged += TextboxSizeChanged;
        }
        //Tab Selected
        private void tabControl1_Selected(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("tab selected");
            this.Text = "TextBox Width: " + this.textBox1.Width.ToString();
        }
        private void TextboxSizeChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Textbox resized");
        }</code></pre>
