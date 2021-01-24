    public async Task<OrdeListViewModel> Handle(GetAllOrdersByUserQuery request, CancellationToken cancellationToken)
    {
        OrdeListViewModel model = new OrdeListViewModel();
        if (request.AcceptedOrCreatedBit) // true for OrderAcceptedByUser
        {
            
                model.Orders = await _context.Order
                .Where(x => x.AcceptedByUserId == request.UserId)
                .Select(OrderDto.Projection)
                .OrderBy(o => o.Registration)
                .ToListAsync(cancellationToken)
            
        }
        else // false for OrderCreatedByUser
        {
            
                model.Orders = await _context.Order
                .Where(x => x.CreatedByUserId == request.UserId)
                .Select(OrderDto.Projection)
                .OrderBy(o => o.Registration)
                .ToListAsync(cancellationToken)
            
        }
        return model;
    }
