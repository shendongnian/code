    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    
    namespace MyCustomControls
    {
    public delegate void MyDelegate(Object sender, EventArgs e);
    class MyListView : ListView
    {
        private static readonly object EventRightClickRaised = new object();
        public MyListView() 
        {
            //RightClick += new MyDelegate(OnRightClick);
        }
        public event EventHandler RightClick
        {
            add
            {
                Events.AddHandler(EventRightClickRaised, value);
            }
            remove
            {
                Events.RemoveHandler(EventRightClickRaised, value);
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                OnRightClick(EventArgs.Empty);
            }
            base.OnMouseUp(e);
        }
        protected void OnRightClick(EventArgs e)
        {
            EventHandler RightClickRaised = (EventHandler)Events[EventRightClickRaised];
            if (RightClickRaised != null)
            {
                RightClickRaised(this, e);
            }
        }
        
    }
    }
