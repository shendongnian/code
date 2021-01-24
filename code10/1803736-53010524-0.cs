    private void Form1_Load(object sender, EventArgs e)
            {
                int h = Screen.PrimaryScreen.WorkingArea.Height;
                int w = Screen.PrimaryScreen.WorkingArea.Width;
                this.ClientSize = new Size(w, h);
            }
