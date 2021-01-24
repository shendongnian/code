    [Serializable]
    public class StoreSpriteItem 
    {
        public string spriteName;
        public int cost;
        public Sprite sprite;
        public bool IsAvailable;
        // also here you could/should implement some methods e.g.
        public void BuyItem()
        {
            IsAvailable = true;
        }
    }
