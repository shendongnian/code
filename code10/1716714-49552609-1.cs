    btn1.Click += new System.EventHandler(this.btn_Click);
    btn2.Click += new System.EventHandler(this.btn_Click);
    btn3.Click += new System.EventHandler(this.btn_Click);
   
    ...
    // event handler`enter code here`
    
    void btn_Click(object sender, EventArgs e)
    {
        
        var button = sender as button;
        // if here if you need it
        DoSomething(button);
    }
    //Joni's DoSomething function and Tag prop into account
    void DoSomething(Button button)
    {
        if(btn.Tag == 'X') 
        {
            //do something
        }
        else
        {
        }
    }
