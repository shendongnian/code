        ....
    InitializeComponent();
            foreach (Control ctrl in this.Controls)
                    {
                        ctrl.MouseMove += new MouseEventHandler(globalMouseMove);
                    }
        ....
        
         private void globalMouseMove(object sender, MouseEventArgs e)
                {
                    //TODO
                }
