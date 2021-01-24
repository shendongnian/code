    GroupBox GetGroupBox(string header, bool addEventHandler = false)
            {
                GroupBox box = new GroupBox()
                {
                    AutoSize = true,
                    Name = header
                };
                TableLayoutPanel layout = new TableLayoutPanel()
                {
                    AutoSize = true
                };
                layout.Controls.Add(new Label() { Text = header });
                box.Controls.Add(layout);
    
                for (uint i = 0; i < 2; ++i)
                {
                    var rbtn = new RadioButton() { Text = i.ToString() };
                    if (addEventHandler)
                    {
                        rbtn.Click += Form1_Click;
                    }                
                    layout.Controls.Add(rbtn);
                }
                    
                return box;
            }
    
            public Form1()
            {
                InitializeComponent();
    
                TableLayoutPanel layout = new TableLayoutPanel()
                {
                    AutoSize = true
                };
                layout.Controls.Add(GetGroupBox("Group box 1"));
                layout.Controls.Add(new Label() { Text = new string('-', 10) });
                layout.Controls.Add(GetGroupBox("Group box 2", true));
                Controls.Add(layout);
            }
    
            private void Form1_Click(object sender, EventArgs e)
            {
                var group1Selected = this.Controls[0].Controls[0].Controls[0].Controls;
                var senderControl = (RadioButton)sender;
    
                if (senderControl.Parent.Parent.Name == "Group box 2")
                {
                    for (int i = 0; i < group1Selected.Count; i++)
                    {
                        if (group1Selected[i] is RadioButton)
                        {
                            var rb = group1Selected[i] as RadioButton;
                            if (rb.Checked)
                            {
                                DialogResult rst = MessageBox.Show("Expected Message: " + rb.Text);
                            }
                        }
                    }
                }            
            }
    
