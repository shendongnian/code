    btn1.Click += new System.EventHandler(this.btn_Click);
    btn2.Click += new System.EventHandler(this.btn_Click);
    btn3.Click += new System.EventHandler(this.btn_Click);
   
    ...
    
    void btn_Click(object sender, EventArgs e)
    {
        
        var button = sender as button;
        // if here if you need it
        //if(button.Tag == 'X') or if (button.Text == 'X') 
        //{
        //    do something
        //}
        //else
        //{
        //}
    }
