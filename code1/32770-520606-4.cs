     IPHostEntry ipE = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress[] IpA = ipE.AddressList;
        for (int i = 0; i < IpA.Length; i++)
        {
              if (!IpA[i].ToString().Contains(":"))
              {
                   ToolStripMenuItem subItem = new ToolStripMenuItem(IpA[i].ToString());
                   subItem.MouseDown += new MouseEventHandler(subItem_MouseDown);
                   cxItems.Items.Add(subItem);
              }
        }
    
        void subMenuitem1_MouseDown(object sender, MouseEventArgs e)
        {
              //get a reference to the menu that was clicked
              ToolStripMenuItem clickedMenu = sender as ToolStripMenuItem;
              //e.Button will tell you which button was clicked.
        }
