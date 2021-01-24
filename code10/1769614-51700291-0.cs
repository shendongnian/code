    public class View1 : ContentView
    {
        public Entry Entry1 { get; private set; }
        public Entry Entry2 { get; private set; }
        public View1 ()
        {
            Entry1 = new Entry { Placeholder = "entry1 View 1" };
            Entry2 = new Entry { Placeholder = "entry1 View 2" };
            Content = new StackLayout {
                Children = {
                    new Label { Text = "View 1" },
                    Entry1,
                    Entry2
                }
            };
        }
    }
