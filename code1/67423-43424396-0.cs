    using System.Collections.Generic;
 
    namespace ItemsControl
    {
       public class Item
       {
          public Item(string title)
          {
             Title = title;
          }
     
          public string Title { get; set; }
       }
     
       public class MainWindowViewModel
       {
          public MainWindowViewModel()
          {
             Titles = new List<Item>()
             {
                new Item("Slide 1"),
                new Item("Slide 2"),
                new Item("Slide 3"),
                new Item("Slide 4"),
                new Item("Slide 5"),
                new Item("Slide 6"),
                new Item("Slide 7"),
                new Item("Slide 8"),
             };
          }
     
          public List<Item> Titles { get; set; }
       }
    }
