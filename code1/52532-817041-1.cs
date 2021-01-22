       public delegate void IsClosing(object sender, DialogResult rsl);
    
            public event IsClosing FormIsClosing;
    
         
            private void Form2_FormClosed(object sender, FormClosedEventArgs e)
            {
                FormIsClosing(this, System.Windows.Forms.DialogResult.Yes);
            }
