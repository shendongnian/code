    static void DoForEachControl (Control c, Action<Control> f){
      c.Controls.ForEach(c => {f(c); DoForEachControl(c, f);})
    }
    
    DoForEachControl(this, c => c.Visible = false); 
 
