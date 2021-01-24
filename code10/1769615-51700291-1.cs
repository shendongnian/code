    public class View1ViewModel
    {
        public string Entry1 { get; set; }
        public string Entry2 { get; set; }
    }
    public class View1 : ContentView
    {
        public View1ViewModel ViewModel { get; private set; }
        public View1 ()
        {
            ViewModel = BindingContext = new View1ViewModel();
            var entry1 = new Entry { Placeholder = "entry1 View 1" };
            var entry2 = new Entry { Placeholder = "entry1 View 2" };
            entry1.SetBinding(Entry.TextProperty, "Entry1");
            entry2.SetBinding(Entry.TextProperty, "Entry2");
            Content = new StackLayout {
                Children = {
                    new Label { Text = "View 1" },
                    entry1,
                    entry2
                }
            };
        }
    }
