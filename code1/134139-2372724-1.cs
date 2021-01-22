    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace ColorGridRow
    {
        public partial class MainPage : UserControl
        {
            public MainPage()
            {
                InitializeComponent();
                DataContext = new List<Sample>
                    {
                        new Sample("1", DateTime.Now + TimeSpan.FromSeconds(1), DateTime.Now + TimeSpan.FromSeconds(3)),
                        new Sample("2", DateTime.Now + TimeSpan.FromSeconds(2), DateTime.Now + TimeSpan.FromSeconds(4)),
                        new Sample("3", DateTime.Now + TimeSpan.FromSeconds(3), DateTime.Now + TimeSpan.FromSeconds(5)),
                    };
            }
        }
    
        public class Sample : INotifyPropertyChanged
        {
            private SolidColorBrush _savedRowBackground;
            private SolidColorBrush _rowBackground;
    
            public string Value { get; private set; }
            public DateTime Begin { get; private set; }
            public DateTime End { get; private set; }
    
            public SolidColorBrush RowBackground
            {
                get { return _rowBackground; }    
                set
                {
                    _rowBackground = value;
                    NotifyPropertyChanged("RowBackground");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
            private void NotifyPropertyChanged(string propertyName)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public Sample(string value, DateTime begin, DateTime end)
            {
                Value = value;
                Begin = begin;
                End = end;
                RowBackground = new SolidColorBrush(Colors.Red);
    
                Observable.Timer(new DateTimeOffset(begin)).Subscribe(_ =>
                {
                    _savedRowBackground = _rowBackground;
                    RowBackground = new SolidColorBrush(Colors.Yellow);
                });
    
                Observable.Timer(new DateTimeOffset(end)).Subscribe(_ => RowBackground = _savedRowBackground);
                
            }
        }
    }
