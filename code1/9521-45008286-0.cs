         //Container ------------------------------------
         Panel Container = new Panel();
         //Top-Docked Element ---------------------------
         ButtonArea = new FlowLayoutPanel();
         Container.Controls.Add(ButtonArea);
         Container.Controls.SetChildIndex(ButtonArea, 1);
         ButtonArea.Dock = DockStyle.Top;
            
         //Fill-Docked Element --------------------------
         box = new RichTextBox();
         Container.Controls.Add(box);
         Container.Controls.SetChildIndex(box, 0); //setting this to 0 does the trick
         box.Dock = DockStyle.Fill;
