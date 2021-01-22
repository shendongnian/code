    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows.Forms;
    class Foo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            Debug.WriteLine(ToString());
        }
        private void SetField<T>(ref T field, T value, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);            
            }
        }
        private DateTime start, end;
        public DateTime Start { get { return start; } set { SetField(ref start, value, "Start"); } }
        public DateTime End { get { return end; } set { SetField(ref end, value, "End"); } }
    }
    
    class BindableCalendar : MonthCalendar
    {
        public DateTime ActualSelectionStart
        {
            get { return SelectionRange.Start; }
            set { if (ActualSelectionStart != value) { SetSelectionRange(value, ActualSelectionEnd); } }
        }
        public DateTime ActualSelectionEnd
        {
            get { return SelectionRange.End; }
            set { if (ActualSelectionEnd != value) { SetSelectionRange(ActualSelectionStart, value); } }
        }
        // should really use EventHandlerList here...
        public event EventHandler ActualSelectionStartChanged, ActualSelectionEndChanged;
    
        DateTime lastKnownStart, lastKnownEnd;
        protected override void OnDateChanged(DateRangeEventArgs drevent)
        {
            base.OnDateChanged(drevent);
            if (lastKnownStart != drevent.Start)
            {
                if (ActualSelectionStartChanged != null) ActualSelectionStartChanged(this, EventArgs.Empty);
                lastKnownStart = drevent.Start;
            }
            if (lastKnownEnd != drevent.End)
            {
                if (ActualSelectionEndChanged != null) ActualSelectionEndChanged(this, EventArgs.Empty);
                lastKnownEnd = drevent.End;
            }
        }
    
    }
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            MonthCalendar cal;
            Button btn;
            using (Form form = new Form
            {
                Controls = {
                    (cal = new BindableCalendar { Dock = DockStyle.Fill, MaxSelectionCount = 10 }),
                    (btn = new Button { Dock = DockStyle.Bottom, Text = "thwack"})
                }
            })
            {
                Foo foo = new Foo { Start = DateTime.Today, End = DateTime.Today.AddDays(1) };
                cal.DataBindings.Add("ActualSelectionStart", foo, "Start").DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                cal.DataBindings.Add("ActualSelectionEnd", foo, "End").DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                btn.Click += delegate
                {
                    foo.Start = foo.Start.AddDays(1);
                    foo.End = foo.End.AddDays(1);
                };
                Application.Run(form);
            }
        }
    }
