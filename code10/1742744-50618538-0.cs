    namespace ItemManagement
    {
        public class Item : IAggregateRoot // For clarity
        {
            public int ItemId {get; private set;}
            public string Description {get; private set;}
            public decimal Price {get; private set;}
            public Color Color {get; private set;}
            public Brand Brand {get; private set;} // In this context, Brand is an entity and not a root
    
            public void ChangeColor(Color newColor){//...}
            // More logic relevant to the management of Items.
        }
    }
