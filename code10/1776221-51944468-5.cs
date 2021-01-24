    var x = dbContext.Junctions                              // from all junctions
        .Where(junction => junction.ProductId == productId)  // take only the ones with productId
                                                              // The first join:
        .Join(dbContext.Parts,                                // Join with Parts
            junction => junction.PartId,                      // from the Junction take the PartId,
            part => part.Id,                                  // from the Parts take the Id
            (junction, part) => new                           // when they match make one new object
            {                                                 // containing some properties
                EnumerationId = junction.EnumId,
                PartNumber = part.Number,
                PartDescription = part.Description,
            })
                                                              // Second Join
            .Join(dbContext.Enumerations,                     // Join with enumerations
                junction => junction.EnumerationId,           // from the 1st join result take EnumerationId
                enumeration => enumeration.Id,                // from enumerations take Id
                (junction, enumeration) => new                // when they match make one new object
                {                                             // containing your desired properties
                    EnumerationCode = enumeration.Code,
                    PartNumber = junction.PartNumber,
                    PartDescription = junction.PartDescription,
                });
