      static Form f1 = new Form();
      static Form f2 = new Form();
      static Form f3 = new Form();
      [STAThread]
      static void Main()
      {
         f1.IsMdiContainer = true;
         f2.MdiParent = f1;
         f3.MdiParent = f1;
         f1.Show();
         f2.Show();
         f3.Show();
         f2.Activated += new EventHandler(f2_Activated);
         Application.Run(f1);
      }
      static void f2_Activated(object sender, EventArgs e)
      {
         f3.Activate();
      }
