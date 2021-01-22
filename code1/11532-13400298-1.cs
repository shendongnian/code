    partial class Customer
    {
        private static readonly CompiledExpression<Employee,IEnumerable<Contract>> activeContractsExpression
            = DefaultTranslationOf<Customer>
              .Property(c => c.ActiveContracts)
              .Is(c => c.Contracts.Where(x => x.ContractEndDate == null));
            
        public IEnumerable<Contract> ActiveContracts
        {
            get 
            { 
                // This is only called when you access your property outside a query
                return activeContractsExpression.Evaluate(this);
            }
        }
    }
