            public CommandValidator()
        {
            //RuleFor(x => x.Estimate).NotNull();
            //RuleFor(x => x.Estimate.Name).NotEmpty();
            //RuleFor(x => x.Estimate.Variant).NotEmpty();
            //RuleFor(x => x.ClientHeader.ClientName).NotEmpty();
            //RuleFor(x => x.ClientHeader.RequestId).NotEmpty();
            RuleFor(x => x).NotNull();
            When(x => x != null, () =>
            {
                RuleFor(x => x.Estimate).NotNull();
                When(x => x.Estimate != null, () =>
                {
                    RuleFor(x => x.Estimate.Name).NotEmpty();
                    RuleFor(x => x.Estimate.Variant).NotEmpty();
                });
                RuleFor(x => x.ClientHeader).NotNull();
                When(x => x.ClientHeader != null, () =>
                {
                    RuleFor(x => x.ClientHeader.ClientName).NotEmpty();
                    RuleFor(x => x.ClientHeader.RequestId).NotEmpty();
                });
            });
        }
