    using System;
    using System.Windows.Forms;
    using CefSharp;
    namespace CefBlog3
    {
      static class Program
      {
    [STAThread]
    static void Main()
    {
      Cef.Initialize(new CefSettings() { CachePath = "Cache" } );
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }
    }
    }
