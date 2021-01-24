    internal static class CardExtensions
    {
        public static T CreateCard<T>(int index, string front, string back) where T : Card
        {
            return (T)Activator.CreateInstance(typeof(T), index, front, back);
        }
    }
    
    internal static class MyExtensions
    {
        public static T CreateDeck<T>(this ObservableCollection<T> deck, int index, string front, string back) where T : Card
        {
            if (deck == null)
                throw new ArgumentNullException();
            var card = CardExtensions.CreateCard<T>(index, front, back);
            deck.Add(card);
            return card;
        }
    }
