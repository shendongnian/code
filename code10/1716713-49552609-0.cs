    btn1.Click += new System.EventHandler(this.btn_Click);
    btn2.Click += new System.EventHandler(this.btn_Click);
    btn3.Click += new System.EventHandler(this.btn_Click);
   
    ...
    // event handler
    
    void btn_Click(object sender, EventArgs e)
    {
       var button = sender as button;
       // if here if you need it
    }
