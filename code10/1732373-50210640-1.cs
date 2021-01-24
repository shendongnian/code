    public override Expression<Func<Customer, bool>> AsExpression()
    {
        return customerFiler => string.IsNullOrWhiteSpace(customerFiler.Name) ||
            customerFiler.Name.Contains(Customer.Name);
    }
