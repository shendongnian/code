    ...
    using Microsoft.Toolkit.Uwp;
    namespace App3
    {
        // Table Row
        public class TStuff
        {
            public string LastName { get; set;}
            public string FirstName { get; set; }
        }
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                A1DataGrid.ItemsSource = new List<TStuff>
                {
                    new TStuff {FirstName="John",  LastName="Smith"},
                    new TStuff {FirstName="Bob",   LastName="Spencer"},
                    new TStuff {FirstName="Betty", LastName="Bennett"},
                    new TStuff {FirstName="Max",   LastName="Harper"}
                };
            } // Constructor Method
        } // Class
    }  // Namespace
