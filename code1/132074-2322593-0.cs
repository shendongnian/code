    class MyData{
       ObservableCollection<Color> Colors;
       ObservableCollection<Fruit> Fruits;
       ObservableCollection<Pairs> Pairs;
       public void MatchCurrentSelection(){
            var selectedColor = CollectionViewSource.GetDefaultView(Colors).CurrentItem;
            var selectedFruit = CollectionViewSource.GetDefaultView(Fruits).CurrentItem;
            if(selectedColor != null && selectedFruit != null){
                 Colors.Remove(selectedColor);
                 Fruits.Remove(selectedFruit);
                 Pairs.Add(new Pair(selectedColor, selectedFruit));
            }
       }
    } 
