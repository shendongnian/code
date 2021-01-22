    public class OrderValidator : IValidator<Order>, IValidator<BaseEntity>
    {
        public bool IsValid(Order obj)
        {
            // do validation
            // ...
            return true;
        }
        public bool IsValid(BaseEntity obj)
        {
            Order orderToValidate = obj as Order;
            if (orderToValidate != null)
            {
                return IsValid(orderToValidate);
            }
            else
            {
                // Eiter do this:
                throw new InvalidOperationException("This is an order validator so you can't validate objects that aren't orders");
                // Or this:
                return false;
                // Depending on what it is you are trying to achive.
            }
        }
    }
