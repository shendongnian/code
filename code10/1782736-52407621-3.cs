    public class ChildModelValidator : BaseModelValidator<ChildModel>
    {
        public ChildModelValidator() 
            : base()
        {
            RuleFor(x => x.IdOfSthInDb)
                .MustAsync(ItemMustExists)
                .WithMessage("Item does not exist.");
        }
        private Task<bool> ItemMustExists(int arg1, CancellationToken arg2)
        {
            return Task.FromResult(false); // some logic here
        }
    }
