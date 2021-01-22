    namespace WpfApplication17
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            public Window1()
            {
                Dictionary<string, Drink> d = new Dictionary<string, Drink>();
                d.Add("A", new Drink("Nehi", 0));
                d.Add("B", new Drink("Moxie", 1));
                d.Add("C", new Drink("Vernor's", 2));
                d.Add("D", new Drink("Canfield's", 3));
                Resources["Drinks"] = d;
                InitializeComponent();
            }
            public class Drink
            {
                public Drink(string name, int popularity)
                {
                    Name = name;
                    Popularity = popularity;
                }
                public string Name { get; set; }
                public int Popularity { get; set; }
            }
        }
    }
