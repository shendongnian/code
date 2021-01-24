    using System;
    using System.Windows;
    using System.Windows.Media;
    
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Infragistics.Windows.DataPresenter;
    
    namespace IGFindRow
    {  
        public partial class MainWindow : Window
        {
    
            public MainWindow()
            {
                _cars = Cars;
                InitializeComponent();
            }        
            
            #region Code fragment from samples provided by Infragistics 
    
            public ObservableCollection<Car> _cars = null;
    
            public ObservableCollection<Car> Cars
            {
                get
                {
                    if (this._cars == null)
                    {
                        this._cars = new ObservableCollection<Car>();
                        this._cars.Add(new Car("Dodge", "Ram", Colors.Blue, 22050.00, 153));
                        this._cars.Add(new Car("Ford", "Explorer", Colors.Green, 27175.00, 96));
                        this._cars.Add(new Car("BMW", "Z4", Colors.Silver, 35600.00, 42));
                        this._cars.Add(new Car("Toyota", "Camry", Colors.Black, 20790.99, 131));
                    }
    
                    return _cars;
                }
            }
    
            public class Car : INotifyPropertyChanged
            {
                string m_make;
                string m_model;
                Color m_color;
                double m_baseprice;
                int m_milage;
    
                public Car(string make, string model, Color color, double baseprice, int milage)
                {
                    this.Make = make;
                    this.Model = model;
                    this.Color = color;
                    this.BasePrice = baseprice;
                    this.Milage = milage;
                }
    
                public string Make
                {
                    get { return m_make; }
                    set
                    {
                        if (m_make != value)
                        {
                            m_make = value;
                            NotifyPropertyChanged("Make");
                        }
                    }
                }
    
                public string Model
                {
                    get { return m_model; }
                    set
                    {
                        if (m_model != value)
                        {
                            m_model = value;
                            NotifyPropertyChanged("Model");
                        }
                    }
                }
    
                public Color Color
                {
                    get { return m_color; }
                    set
                    {
                        if (m_color != value)
                        {
                            m_color = value;
                            NotifyPropertyChanged("Color");
                        }
                    }
                }
    
                public double BasePrice
                {
                    get { return m_baseprice; }
                    set
                    {
                        if (m_baseprice != value)
                        {
                            m_baseprice = value;
                            NotifyPropertyChanged("BasePrice");
                        }
                    }
                }
    
                public int Milage
                {
                    get { return m_milage; }
                    set
                    {
                        if (m_milage != value)
                        {
                            m_milage = value;
                            NotifyPropertyChanged("Milage");
                        }
                    }
                }
    
    
                public event PropertyChangedEventHandler PropertyChanged;
                private void NotifyPropertyChanged(String info)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
                }
    
            }
    
            #endregion
    
            private void Search_Click(object sender, RoutedEventArgs e)
            {
                // Enumerate records 
                foreach (var it in dataGrid.FieldLayouts.DataPresenter.Records)
                {
                    if (it is DataRecord record)
                    {
                        // Check the current column value
                        if (record.Cells["Make"].Value.ToString().ToUpper() == Maker.Text.ToUpper())
                        {
                            record.IsSelected = true;
                            break;
                        }
                    }
                }
            }
        } 
    }
