      private void Form1_Shown (object sender, EventArgs e)
      {
         linkLabel1.Links.Add (0, 7, "http://bobmoore.mvps.org/");
         linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
      }
      private void linkLabel1_LinkClicked (object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
      {
         this.linkLabel1.Links[linkLabel1.Links.IndexOf (e.Link)].Visited = true;
         string target = e.Link.LinkData as string;
         System.Diagnostics.Process.Start (target);
      }
