    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Data;
    using System.Windows;
    using System.ComponentModel;
    using System.Windows.Controls;
    namespace NumberedListBox
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                Persons = new ObservableCollection<Person>();
                Persons.Add(new Person() { Name = "Sally", Age = 34 });
                Persons.Add(new Person() { Name = "Bob", Age = 18 });
                Persons.Add(new Person() { Name = "Joe", Age = 72 });
                Persons.Add(new Person() { Name = "Mary", Age = 12 });
                CollectionViewSource view = FindResource("sortedPersonList") as CollectionViewSource;
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                
                DataContext = this;
            }
            public ObservableCollection<Person> Persons { get; private set; }
            private void SortButton_Click(object sender, RoutedEventArgs e)
            {
                Button button = sender as Button;
                string sortProperty = button.Tag as string;
                CollectionViewSource view = FindResource("sortedPersonList") as CollectionViewSource;
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(sortProperty, ListSortDirection.Ascending));
                view.View.Refresh();
            }
        }
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
