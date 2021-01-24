        public void NewsList_Selected(Object sender, SelectedItemChangedEventArgs e)
        {
             var a = e.SelectedItem as NewsEntry;
             var b = from c in newsEntries
               where (a == c)
               select c;
             foreach(NewsEntry d in b)
            {
              d.Text = d.TextFull;
            }
             FooCollection = newsEntries; // This will do the rest for you 
        }
