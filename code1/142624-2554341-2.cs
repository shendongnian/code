    in the constructor:
    button1.MouseHover += new EventHandler(button1_MouseHover); 
    button1.MouseMove += new MouseEventHandler(button1_MouseMove);
    
    void button1_MouseMove(object sender, MouseEventArgs e)
              {
                   this.button1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.img2));
              }
    
              void button1_MouseHover(object sender, EventArgs e)
              {
                   this.button1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.img2));
              }
