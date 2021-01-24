    abstract class WorkItem {
        public virtual void Validate() {
            if (Discount > MaximumDiscount)
                throw new InvalidOperationException("Discount is way to high!");
   
            if (Quantity < MinimumQuantityForDiscount)
                throw new InvalidOperationException("Order is not eligible for discount.");
        }
    }
    
    sealed class OnlineOrder : WorkItem {
        public override Validate() {
            base.Validate();
    
            // More validation rules, specific for OnlineOrder
        }
    }
