    public partial class Window1
    {
        public Window1()
        {
            InitializeComponent();
            myListbox.ItemsSource = new[]
                                        {
                                            new Contact { ContactFirstName = "Stack", ContactLastName = "Overflow", ContactNumber = 1 },
                                            new Contact { ContactFirstName = "Stack", ContactLastName = "Overflow", ContactNumber = 2 },
                                            new Contact { ContactFirstName = "Stack", ContactLastName = "Overflow", ContactNumber = 3 },
                                        };
        }
    }
    public class Contact
    {
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public int ContactNumber { get; set; }
    }
