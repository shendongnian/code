    using System;
    using System.Threading;
    using Gtk;
    
    public partial class MainWindow : Gtk.Window
    {
        public MainWindow() : base(Gtk.WindowType.Toplevel)
        {
            Build();
        }
    
        protected void OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
            a.RetVal = true;
        }
    
        protected async void OnButtonClicked(object sender, EventArgs e)
        {
            textview.Buffer.Text = "Hello, world!";
            textview.Buffer.Text += Environment.NewLine;
            await Task.Delay(2500);
            textview.Buffer.Text += "Hello, world!";
        }
    }
