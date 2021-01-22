    using System;
    using System.Collections.Generic;
    using System.Windows;
    
    namespace GridTest
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                dataGrid.ItemsSource = new List<Person>(
                    new Person[]
                    {
                        new Person("Bob", 30),
                        new Person("Sally", 24),
                        new Person("Joe", 17)
                    });
            }
        }
    
        public class Person
        {
            public String Name { get; set; }
            public int Age { get; set; }
    
            public Person(String name, int age)
            {
                Name = name;
                Age = age;
            }
        }
    }
