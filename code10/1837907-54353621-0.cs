    public abstract class Product {
        protected string Name;
        protected int Quantity;
        public override string ToString() {
            return $"Name = {Name}, Quantity = {Quantity}";
        }
    }
