    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows;
    
    namespace TestDemo
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Books = new Dictionary<Book, int>();
                Books.Add(new Book() { Name = "Book 1"}, 1);
                Books.Add(new Book() { Name = "Book 2" }, 2);
                Books.Add(new Book() { Name = "Book 3" }, 3);
    
                SelectedBookIndex = 2;
    
                DataContext = this;
            }
    
            public Dictionary<Book, int> Books { get; set; }
    
            private int _selectedBookIndex;
            public int SelectedBookIndex
            {
                get { return _selectedBookIndex; }
                set
                {
                    _selectedBookIndex = value;
                    Debug.WriteLine("Selected Book Index=" + _selectedBookIndex);
                }
            }
        }
    
        public class Book
        {
            public string Name { get; set; }
        }
    }
