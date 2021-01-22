    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    using System.Windows.Threading;
    using System.Windows;
    namespace WpfApplication1
    {
        public class Notification
        {
            public DateTime TimeStamp { get; set; }
        }
    
        public class NotificationCollection : ObservableCollection<Notification>
        {
            private readonly TimeSpan timeout;
    
            private DispatcherTimer timer;
    
            public NotificationCollection(TimeSpan timeout)
                : this(timeout, Application.Current.Dispatcher) { }
    
            public NotificationCollection(TimeSpan timeout, Dispatcher dispatch)
            {
                this.timeout = timeout;
                timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, this.Cleanup, dispatch);
            }
    
            protected override void InsertItem(int index, Notification item)
            {
                base.InsertItem(index, item);
                timer.Start();
            }
    
            private void Cleanup(object o, EventArgs e)
            {
                timer.Stop();
                // Sanity
                if (this.Count == 0)
                    return;
    
                var deadList = from note in this.Items
                               where note.TimeStamp + this.timeout - DateTime.UtcNow < TimeSpan.Zero
                               select note;
                foreach (var note in deadList)
                {
                    this.Remove(note);
                }
    
                if (this.Count > 0)
                    timer.Start();
            }
        }
    }
