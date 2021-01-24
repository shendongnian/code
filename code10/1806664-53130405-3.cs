    /// <summary>
    /// To apply multiple discount rules to an order item
    /// </summary>
    public class CompositeDiscountRule : IDiscountRule
    {
        private readonly List<Type> _discountTypes;
        public CompositeDiscountRule()
        {
            _discountTypes = new List<Type>();
        }
        public CompositeDiscountRule(List<Type> discountTypes)
        {
            if (discountTypes == null)
            {
                throw new ArgumentNullException(nameof(discountTypes));
            }
            _discountTypes = discountTypes;
        }
        public void Register<T>() where T : IDiscountRule, new()
        {
            _discountTypes.Add(typeof(T));
        }
        /// <inheritdoc />
        public decimal CalculateDiscount(OrderItem item)
        {
            decimal totalDiscount = 0;
            foreach (var discountType in _discountTypes)
            {
                IDiscountRule rule = Activator.CreateInstance(discountType) as IDiscountRule;
                if (rule != null)
                {
                    totalDiscount += rule.CalculateDiscount(item);
                }
            }
            return totalDiscount;
        }
    }
