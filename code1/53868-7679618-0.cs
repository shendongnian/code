    protected void Application_Start(object sender, EventArgs e)
    {
      string p1 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
      string p2 = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
      string p3 = this.Server.MapPath("");
      Console.WriteLine("p1 = " + p1);
      Console.WriteLine("p2 = " + p2);
      Console.WriteLine("p3 = " + p3);
    }
