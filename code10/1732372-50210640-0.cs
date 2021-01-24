    public override Expression<Func<Customer, bool>> AsExpression()
    {
        return customerFiler => string.IsNullOrWhitespace(customerFiler.Name) ||
            customerFiler.Name.Contains(Customer.Name);
    }
