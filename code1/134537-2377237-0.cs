     public partial class Form2 : Form
        {
            Button reset = new Button();
            Button compute = new Button();
            Panel pnl = new Panel();
    
            public Form2()
            {
               
                reset.Text = "reset";
                compute.Text = "compute";
                pnl.Name = "pnl";
    
                reset.Click += new EventHandler(reset_Click);
                compute.Click += new EventHandler(compute_Click); 
    
                this.Controls.Add(compute);
                this.Controls.Add(reset);
                this.Controls.Add(pnl);
    
                init();
    
                foreach (Control ctl in this.Controls)
                {
                    ctl.Dock = DockStyle.Top;
                }
    
                
            }
    
            void compute_Click(object sender, EventArgs e)
            {
                int tot=0;
                foreach (TextBox txt in pnl.Controls)
                {
                    tot += int.Parse(txt.Text);
                }
    
                MessageBox.Show("total is:" + tot.ToString());
            }
    
            void reset_Click(object sender, EventArgs e)
            {
                foreach (TextBox txt in pnl.Controls)
                {
                    txt.Text = "0";
                }
            }
    
            private void init()
            {   
                pnl.Controls.Clear();
                
                //5 textbox
                for (int i = 0; i <= 5; i++)
                {
                    TextBox t = new TextBox();
                    t.Dock = DockStyle.Top;
                    t.Text = "0";
                    this.Controls["pnl"].Controls.Add(t);                
                }
            }
    
        }
