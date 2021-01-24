    /// <summary>
    /// Abstract base class for the discount rules
    /// </summary>
    public abstract class DiscountRule : IDiscountRule
    {
        private readonly int _percent;
        protected DiscountRule(int percent)
        {
            _percent = percent;
        }
        /// <inheritdoc />
        public decimal CalculateDiscount(OrderItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            decimal discount = item.Total * (decimal) (_percent/100.0);
            return discount;
        }
    }
    /// <summary>
    /// 2% discount
    /// </summary>
    public class BasicDiscountRule : DiscountRule
    {
        public BasicDiscountRule() : base(2)
        {
            
        }
    }
    /// <summary>
    /// 5% discount
    /// </summary>
    public class SilverDiscountRule : DiscountRule
    {
        public SilverDiscountRule() : base(5)
        {
        }
    }
    /// <summary>
    /// 10% discount
    /// </summary>
    public class GoldDiscountRule : DiscountRule
    {
        public GoldDiscountRule() : base(10)
        {
            
        }
    }
