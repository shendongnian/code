    public class Item {
      DateTime Date { get; set; }
    }
    
    var data = new List<Item>();
    
    data.Add(new Item { Date = DateTime.Now };
    data.Add(new Item { Date = DateTime.Now.AddDays(1) };
    data.Add(new Item { Date = DateTime.Now.AddDays(2) };
    
    MainCarouselView.ItemsSource = data;
