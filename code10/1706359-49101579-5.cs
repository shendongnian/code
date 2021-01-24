    //All the Normal using statements plus a few more...
    using System.Text.RegularExpressions;
    //Uncomment these two for WPF or comment out for UWP
    //using System.Windows;
    //using System.Windows.Controls;
    using NamespaceOfYourApp {
        public class MegaGrid : Grid
        {
            private string zMegaRow = "";
            public string MegaRow
            {
                get { return zMegaRow; }
                set
                {
                    zMegaRow = value;
                    RowDefinitions.Clear();
                    string value2 = Regex.Replace(value, @"\s+", "");
                    string[] items = value2.Split(',');
                    foreach (string item in items)
                    {
                        GridLengthConverter converter = new GridLengthConverter();
                        RowDefinitions.Add(
                              new RowDefinition { Height = (GridLength)converter.ConvertFromString(item) }
                            );
                    }
                }
            } // MegaRow
            private string zMegaCol = "";
        private object converter;
        public string MegaCol
            {
                get { return zMegaCol; }
                set
                {
                    zMegaRow = value;
                    ColumnDefinitions.Clear();
                    string value2 = Regex.Replace(value, @"\s+", "");
                    string[] items = value2.Split(',');
                    GridLengthConverter converter = new GridLengthConverter();
                    foreach (string item in items)
                    {                        
                        ColumnDefinitions.Add(
                            new ColumnDefinition { Width = (GridLength)converter.ConvertFromString(item) }
                        );
                    }
                }
            } // MegaCol
        } // Class
    } //NameSpaceOfYourApp
