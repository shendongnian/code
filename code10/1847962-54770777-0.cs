    public CardInformationRequestValidator()
    {
        RuleFor(x => x.Request)
            .NotNull()
            .DependentRules(() =>
            {
                RuleFor(x => x.Request.RU)
                    .NotNull()
                    .NotEmpty();
                RuleFor(x => x.Request.Currency)
                    .NotNull()
                    .NotEmpty();
                RuleFor(x => x.Request.AccountNumber)
                    .NotNull()
                    .NotEmpty();
            });
    }
