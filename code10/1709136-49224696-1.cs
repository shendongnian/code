    using System;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    namespace DeleteButton
    {
	    public partial class MainPage : ContentPage
	    {
            ObservableCollection<String> list;
            public MainPage()
		    {
			    InitializeComponent();
    		}
            protected override void OnAppearing()
            {
                base.OnAppearing();
                list = new ObservableCollection<string>()
                {
                    "Task 1", "Task 2", "Task 3", "Task 4", "Task 5",
                    "Task 6", "Task 7", "Task 8", "Task 9", "Task 10"                    
                };
        
                listView.ItemsSource = list;
            }
            public void Delete(Object Sender, EventArgs args)
            {
                Button button = (Button)Sender;
                StackLayout listViewItem = (StackLayout)button.Parent;
                Label label = (Label)listViewItem.Children[0];
            
                String text = label.Text;
                list.Remove(text);
            }
        }
    }
