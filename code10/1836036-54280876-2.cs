    using System;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    namespace Playpen
    {
        public partial class MainPage : ContentPage
        {
            public ObservableCollection<ListItem> DataSource { get; set; }
            public MainPage()
            {
                this.BindingContext = this;
                DataSource = new ObservableCollection<ListItem>();
                DataSource.Add(new ListItem() { Text = "Item 1", SubText = "Sub Item Text 1" });
                DataSource.Add(new ListItem() { Text = "Item 2", SubText = "Sub Item Text 2" });
                DataSource.Add(new ListItem() { Text = "Item 3", SubText = "Sub Item Text 3" });
                InitializeComponent();
            }
        }
    }
