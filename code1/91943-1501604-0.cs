    private List<Control> listControl;
    
            public windowForm()
            {
                InitializeComponent();
                listControl = new List<Control>(); 
            } 
    
            public List<Control> ListControl {
                get { return listControl; }
            }
    
            public void addControl() {
                if (this.listControl.Count() > 0) {
                    foreach (Control c in listControl)
                    {
                        Console.WriteLine("adding "+c.Name);
                        this.panel1.Controls.Add(c);
                    }
                }
            }
    
            public void removeControl() {
                if (this.listControl.Count() > 0)
                {
                    foreach (Control c in listControl)
                    {
                        Console.WriteLine("removing " + c.Name);
                        this.panel1.Controls.Remove(c);
                    }
                }
            }
