    FormA : Form 
    {
       ...
       protected System.Windows.Forms.Button buttonBase = new System.Windows.Forms.Button();
       this.buttonBase.Click += new System.EventHandler(this.buttonBase_Click);
       
       protected virtual void buttonBase_Click(object sender, EventArgs e)
       {
           MessageBox.Show("Hi from base", "Hello");
       }
    }
    FormB : FormA
    {
       ...
       // comment or remove line below, othervise you'll see "Hi from inherited form" twice
       // this.buttonBase.Click += new System.EventHandler(this.buttonBase_Click);         
       
       protected override void buttonBase_Click(object sender, EventArgs e)
       {
           MessageBox.Show("Hi from inherited form", "Elo");
       }
    }
