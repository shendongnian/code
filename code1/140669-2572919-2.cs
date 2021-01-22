        class CircularStore : IItemStore
        {
            private List<Slot> slots;
            private int freeSlotCount;
            private int position = -1;
            public CircularStore(int capacity)
            {
                slots = new List<Slot>(capacity);
            }
            public T Fetch()
            {
                if (Count == 0)
                    throw new InvalidOperationException("The buffer is empty.");
                int startPosition = position;
                do
                {
                    Advance();
                    Slot slot = slots[position];
                    if (!slot.IsInUse)
                    {
                        slot.IsInUse = true;
                        --freeSlotCount;
                        return slot.Item;
                    }
                } while (startPosition != position);
                throw new InvalidOperationException("No free slots.");
            }
            public void Store(T item)
            {
                Slot slot = slots.Find(s => object.Equals(s.Item, item));
                if (slot == null)
                {
                    slot = new Slot(item);
                    slots.Add(slot);
                }
                slot.IsInUse = false;
                ++freeSlotCount;
            }
            public int Count
            {
                get { return freeSlotCount; }
            }
            private void Advance()
            {
                position = (position + 1) % slots.Count;
            }
            class Slot
            {
                public Slot(T item)
                {
                    this.Item = item;
                }
                public T Item { get; private set; }
                public bool IsInUse { get; set; }
            }
        }
