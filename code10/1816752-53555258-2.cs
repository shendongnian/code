    public async Task<OrdeListViewModel> Handle(GetAllOrdersByUserQuery request, CancellationToken cancellationToken)
    {
        if (request.AcceptedOrCreatedBit) // true for OrderAcceptedByUser
        {
            var model = new OrdeListViewModel
            {
                Orders = await _context.Order
                .Where(x => x.AcceptedByUserId == request.UserId)
                .Select(OrderDto.Projection)
                .OrderBy(o => o.Registration)
                .ToListAsync(cancellationToken)
            };
        }
        else // false for OrderCreatedByUser
        {
            var model = new OrdeListViewModel
            {
                Orders = await _context.Order
                .Where(x => x.CreatedByUserId == request.UserId)
                .Select(OrderDto.Projection)
                .OrderBy(o => o.Registration)
                .ToListAsync(cancellationToken)
            };
        }
        return model;
    }
