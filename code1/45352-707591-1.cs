        [STAThread]
        static void Main()
        { // example code only... doesn't do cleanup
            Application.EnableVisualStyles();
            Button btn = new Button();
            Form form = new Form();
            form.Controls.Add(btn);
            ToolTip ttip = new ToolTip();
            ttip.SetToolTip(btn, "Hello world");
            Application.Run(form);
        }
