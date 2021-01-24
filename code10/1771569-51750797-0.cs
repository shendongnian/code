        private void CheckAllControls(System.Windows.Forms.Control c1)
        {
            // For all of the child controls in this control
            for (int i = 0; i < c1.Controls.Count; i++)
            {
                // Get the individual child control
                System.Windows.Forms.Control c2 = c1.Controls[i];
                // Check if the control is disposed
                if (c2.IsDisposed)
                { // Breakpoint set here
                }
                c2.Disposed += C2_Disposed;
                // Recursively call this function
                CheckAllControls(c2);
            }
        }
        private void C2_Disposed(object sender, EventArgs e)
        {
          ((Control)sender).MouseMove -=OnMouseMove ;
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
