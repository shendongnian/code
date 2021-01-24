    int ControlsAdded = 0; 
    protected void button_Click(object sender, EventArgs e)
    {
        TextBox selectedText = new TextBox();
        selectedText.Size = new Size(300, this.Font.Height);
        selectedText.Location = new Point(100, ControlsAdded * selectedText.Height + 30);
        ControlsAdded += 1;
        this.Controls.Add(selectedText);
        selectedText.BringToFront();
            
        using (var fBD = new FolderBrowserDialog())  {
            if (fBD.ShowDialog() == DialogResult.OK)
                selectedText.Text = fBD.SelectedPath;
        }
    }
