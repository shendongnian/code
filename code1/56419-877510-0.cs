    [STAThread]
    static void Main() {
        Application.EnableVisualStyles();
        Application.Run(new Form {
            Controls = { new SplitContainer {
                Width = 200,
                IsSplitterFixed = true,
                SplitterDistance = 100,
                SplitterWidth = 1,
                Dock = DockStyle.Fill,
                Panel1 = { Controls = {
                        new ListBox {
                            IntegralHeight = false,
                            Dock = DockStyle.Fill,
                            BackColor = Color.Blue,
                            Items = {"abc","def","ghi"}
                        }
                    }
                }, Panel2 = { Controls = {
                        new ListBox {
                            Dock = DockStyle.Fill,
                            BackColor = Color.Red,
                            IntegralHeight = false,
                            Items = {"jkl","mno","pqr"}
                        }
                    }
                }
            }}
        });        
    }
