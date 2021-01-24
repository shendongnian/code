    public IEnumerable<OrderModel> Parse(string[] input)
        {
        
        (input ?? throw new ArgumentNullException(nameof(input)))
        
                    return _context.OrderModel.Where(m => input.contains(m.ItemName));
        }
