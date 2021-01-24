    public class PurchaseOrderValidator : AbstractValidator<PurchaseOrder>
    {
        public PurchaseOrderValidator()
        {
            RuleFor(x => x.Total).Must(MatchSumOfLineItems);
        }
        private bool MatchSumOfLineItems(PurchaseOrder order, decimal sum)
        {
            return sum == order.LineItems.Sum(i => i.Price);
        }
    }
