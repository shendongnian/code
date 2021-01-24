     public string LastItemsText => Nummer.Last()?.Num;
     public void CountUp()
     {
         int newNumber = Nummer.Count + 1;
         Nummer.Add(new NumberViewModel { Num = newNumber});
         PropertyChanged(this, new PropertyChangedEventArgs(nameof(LastItemsText));
     }
