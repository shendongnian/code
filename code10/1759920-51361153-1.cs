    using System; using System.ComponentModel; using System.Windows; using System.Windows.Controls;
    
    namespace ComboBoxInDataGridExample
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public BindingList<Person> Persons { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                Persons = new BindingList<Person>
                {
                    new Person{
                        day1_f_standby = "Blue",
                        Shifts = new BindingList<Shift>
                    {
                        new Shift{ Description="First shift", ID = 1},
                        new Shift{ Description="Second shift", ID = 2},
                    }
                    },
                    new Person{
                                    day1_f_standby = "Red",
                        Shifts = new BindingList<Shift>
                    {
                        new Shift{ Description="Early shift", ID = 3},
                        new Shift{ Description="Late shift", ID = 4},
                    },
                         Shifts_selectedId = 3
                    }
                };
                DataContext = this;
            }
    
            private void comboBoxShift_DropDownClosed(object sender, EventArgs e)
            {
    
            }
    
            private void comboBoxShift_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
    
            }
        }
    }
