public class PurchaseOrderValidator : AbstractValidator<PurchaseOrder>
{
    public PurchaseOrderValidator()
    {
        RuleFor(x => x.Total).Equal(x => x.LineItems.Sum(item => item.Price));
    }
}
