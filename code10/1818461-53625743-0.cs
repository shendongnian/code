     // we need to comment it as its a single variable, 
     //var destinationSelectedProperties = new { code = string.Empty, name = string.Empty };
    
    var destinations = pricerepository.GetDestinationsBasedOnMarketAndProgram(salesItemRequest);
    
    if (destinations == null || !destinations.Any())
        return StatusCode(StatusCodes.Status204NoContent);
    
    return destinations.Select(u =>new
                    {
                        code = u.Code,
                        name = u.Name
                    }).ToList();
