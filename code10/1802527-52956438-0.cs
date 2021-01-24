        public class StrictTypeEquivalence : IEquivalencyStep
        {          
            public bool CanHandle(IEquivalencyValidationContext context, IEquivalencyAssertionOptions config)
            {
                return context.Subject != null && context.Expectation != null &&
                       context.Subject.GetType() != context.Expectation.GetType();
            }
            public bool Handle(IEquivalencyValidationContext context, IEquivalencyValidator parent, IEquivalencyAssertionOptions config)
            {
                throw new AssertionFailedException($"{context.SelectedMemberPath}: Expected type {context.Expectation.GetType()} but found {context.Subject.GetType()} instead.");
            }
        }
