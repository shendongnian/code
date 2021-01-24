    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    
    namespace HorizontalDataGridMixedContentFromCalc
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private ObservableCollection<Calculation> calculations = new ObservableCollection<Calculation>();
            public ObservableCollection<Calculation> Calculations
            {
                get { return calculations; }
                set { calculations = value; }
            }
    
            public MainWindow()
            {
                InitializeComponent();
                Calculations.Add(new Calculation { a = 3, b = 6, c = true });
                Calculations.Add(new Calculation { a = 3, b = 9, c = false });
                DataContext = this;
            }
    
            public class Calculation : INotifyPropertyChanged
            {
                private int _a;
                public int a
                {
                    get
                    {
                        return _a;
                    }
                    set
                    {
                        _a = value;
                        OnPropertyChanged("d");
                        OnPropertyChanged("e");
                    }
                }
    
                private int _b;
                public int b
                {
                    get { return _b; }
                    set
                    {
                        _b = value;
                        OnPropertyChanged("d");
                        OnPropertyChanged("e");
                    }
                }
    
                private bool _c;
                public bool c
                {
                    get { return _c; }
                    set
                    {
                        _c = value;
                        OnPropertyChanged("f");
                    }
                }
    
                public int d
                {
                    get
                    {
                        return a + b;
                    }
                }
    
                public double e
                {
                    get
                    {
                        if (b == 0) return 0;
                        return (double)(a * a) / (b * b);
                    }
                }
    
                public bool f
                {
                    get
                    {
                        return !c;
                    }
    
                }
    
                protected void OnPropertyChanged(string name)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
                }
    
                public event PropertyChangedEventHandler PropertyChanged;
            }
        }
    }
