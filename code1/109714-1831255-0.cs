     TextBox lbl = new TextBox(); 
                     lbl.Text = Build("20000", i);
                     lbl.Location = new Point(30, 25 * i);
                     lbl.Width = 350;
                     lbl.MouseHover += new EventHandler(lbl_MouseHover);
     
       void lbl_MouseHover(object sender,
     EventArgs e)
             {
                 TextBox t = (TextBox)sender;
                 ListBox lb = new ListBox();
                 for (int i = 0; i < 10; i++)
                 {
                     lb.Items.Add("Hej");
                 }
                 int x = t.Location.X; 
                 int y = t.Location.Y + t.Height;
                 lb.Location = new Point(x, y);
                 panel1.Controls.Add(lb);
                 lb.BringToFront(); 
             }
