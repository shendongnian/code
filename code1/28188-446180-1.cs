    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        TextBox multi, single;
        Button btn;
        using(Form form = new Form {
                Controls = {
                    (multi= new TextBox { Multiline = true, Dock = DockStyle.Fill}),
                    (btn = new Button { Text = "OK", Dock = DockStyle.Bottom,
                        DialogResult = DialogResult.OK}),
                    (single = new TextBox { Multiline = false, Dock = DockStyle.Top}),
                }, AcceptButton = btn                
            })
        {
            multi.GotFocus += delegate { form.AcceptButton = null; };
            multi.LostFocus += delegate { form.AcceptButton = btn; };
            btn.Click += delegate { form.Close(); };
            Application.Run(form);
        }
    }
