    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Data;
    namespace WpfApplication1
    {
        public partial class Window1 : Window, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public List<RowData> Rows { get; set; }
            public List<ColumnOption> ColumnOptions { get; set; }
            private string _column1OptionString;
            public string Column1OptionString
            {
                get
                {
                    return _column1OptionString;
                }
                set
                {
                    _column1OptionString = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Column1OptionString"));
                }
            }
            public Window1()
            {
                InitializeComponent();
                ColumnOptions = new List<ColumnOption>() {
                    new ColumnOption(){ Option = "String", StringFormat = "" },
                    new ColumnOption(){ Option = "Int32", StringFormat = "" }
                };
                Rows = new List<RowData>() {
                    new RowData(){ Column1 = "01234" }
                };
                _column1OptionString = "String";
                this.DataContext = this;
            }
        }
        public class ColumnOption
        {
            public string Option { get; set; }
            public string StringFormat { get; set; }
        }
        public class RowData : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private object _column1;
            public object Column1
            {
                get
                {
                    return _column1;
                }
                set
                {
                    _column1 = value;
                    if (PropertyChanged!= null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Column1"));
                }
            }
        }
        public class RowDataConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (values[1] == null)
                    return values[0].ToString();
                switch (values[1].ToString())
                {
                    case "String":
                        return values[0].ToString();
                    case "Int32":
                        Int32 valueInt;
                        Int32.TryParse(values[0].ToString(), out valueInt);
                        return valueInt.ToString();
                    default:
                        return values[0].ToString();
                }
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
