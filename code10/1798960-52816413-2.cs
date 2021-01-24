        var result = items.AsQueryable().Select(x => new CustomDto()
            {
                Code = x.Code,
                Name = x.Name,
                StatusCode = x.ClaimStatus
            }).ToList();
