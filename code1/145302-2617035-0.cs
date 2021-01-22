    class ItemBase {
    }
    abstract class ItemType {
        public ItemBase Base {
            get { return GetItemBase(); }
            set { SetItemBase(value); }
        }
        protected abstract void SetItemBase(ItemBase value);
        protected abstract ItemBase GetItemBase();
    }
    class ItemType<T> : ItemType where T : ItemBase {
        protected override sealed void SetItemBase(ItemBase value) {
            Base = (T) value;
        }
        protected override sealed ItemBase GetItemBase() {
            return Base;
        }
        public new T Base { get; set; }
    }
