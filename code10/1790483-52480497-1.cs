    abstract class WorkItem {
        public int Quantity {
            get => _quantity;
            protected set {
                Validate(value);
                _quantity = value;
            }
        }
        // Other properties
        // Single method because you cannot change quantity without
        // affecting discount (and vice-versa).
        UpdateOrder(int newQuantity, float discount) {
            Quantity = newQuantity;
            Discount = discount; // Discount validation is maybe affected by Quantity
        }
    
        private int _quantity;
    }
