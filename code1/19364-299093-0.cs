        TextBox tb = new TextBox();
        Button btn = new Button { Dock = DockStyle.Bottom };
        btn.Click += delegate { Debug.WriteLine("Submit: " + tb.Text); };
        tb.KeyDown += (sender,args) => {
            if (args.KeyCode == Keys.Return)
            {
                btn.PerformClick();
            }
        };
        Application.Run(new Form { Controls = { tb, btn } });
