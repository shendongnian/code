    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    class Program
    {
        EventArgs data;
    
        static void Main()
        {
            Program p = new Program();
            p.RunWidget();
        }
    
        public Program()
        {
            _autoEvent = new AutoResetEvent(false);
        }
    
        public void RunWidget()
        {
            ThirdParty widget = new ThirdParty();                   
            widget.Completed += new EventHandler(this.Widget_Completed);
            data = null;
            widget.DoWork();
    
            while (data == null);
                Application.DoEvents();
    
            // do stuff with the results of DoWork that are contained in EventArgs.
        }
    
        // Assumes that some kind of args are passed by the event
        public void Widget_Completed(object sender, EventArgs e)
        {
            data = e;
        }
    }
