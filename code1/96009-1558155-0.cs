    public List<Control> getControls(string what, Control where)
        {
            List<Control> controles = new List<Control>();
            foreach (Control c in where.Controls)
            {
                if (c.GetType().Name == what)
                {
                    controles.Add(c);
                }
                else if (c.Controls.Count > 0)
                {
                    controles.AddRange(getControls(what, c));
                }
            }
            return controles;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            var c = getControls("Button", this);
        
        }
