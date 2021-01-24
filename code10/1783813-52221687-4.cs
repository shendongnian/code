    public class ViewModel
    {
        public ObservableCollection<Card> Cards { get; } = new ObservableCollection<Card>();
        //...
        private void OnDataReceived(List<Reading> readings)
        {
            foreach (Reading r in readings)
            {
                Cards.Add(new Card
                {
                    Id = r.Id,
                    Value = r.Value
                });
            }
        }
    }
