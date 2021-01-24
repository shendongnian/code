    public class Item
    {
        /// <summary>
        /// Kitty already collected this cell or not?
        /// </summary>
        public bool IsCollected { get; private set; }
        /// <summary>
        /// ItemType in this cell
        /// </summary>
        public ItemType ItemType { get; }
        /// <summary>
        /// Represents a single item in each cell.
        /// </summary>
        /// <param name="c">Type of the item decided by char.</param>
        public Item(char c)
        {
            switch (c)
            {
                case '@':
                    ItemType = ItemType.CoderSoul;
                    break;
                case '*':
                    ItemType = ItemType.Food;
                    break;
                case 'x':
                    ItemType = ItemType.DeadLock;
                    break;
            }
        }
        /// <summary>
        /// Collect the item in this cell.
        /// </summary>
        /// <returns>The collected item.</returns>
        public ItemType Collect()
        {
            if (IsCollected)
            {
                return ItemType.None;
            }
            IsCollected = true;
            return ItemType;
        }
    }
