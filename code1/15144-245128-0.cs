        1    class MyToolTip : ToolTip
    
        2     {
    
        3         public MyToolTip()
    
        4         {
    
        5             this.OwnerDraw = true;
    
        6             this.Draw += new DrawToolTipEventHandler(OnDraw);
    
        7 
    
        8         }
    
        9 
    
       10         public MyToolTip(System.ComponentModel.IContainer Cont)
    
       11         {
    
       12             this.OwnerDraw = true;
    
       13             this.Draw += new DrawToolTipEventHandler(OnDraw);
    
       14         }
    
       15 
    
       16         private void OnDraw(object sender, DrawToolTipEventArgs e)
    
       17         {
    
                          ...Code Stuff...
    
       24         }
    
       25     }
