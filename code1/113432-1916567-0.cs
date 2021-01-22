    class Item {
        public string Name = "";
        public int Value = 0;
        public Item(string name, int value) {
            this.Name = name;
            this.Value = value;
        }
        public override string ToString() {
            return this.Name;
        }
    }
