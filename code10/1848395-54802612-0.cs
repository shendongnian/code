    var result = parts.GroupJoin(outputControls,   // GroupJoin Parts and OutputControls
        part => part.Id,                           // from every part take the Id
        outputControl => outputControl.PartId,     // from every outputControl take the PartId
        // result selector: when these Ids match,
        // use the part and all its matching outputControls to make one new object:
        (part, outputControlsOfThisPart) => new
        {
            // select the part properties you plan to use:
            Id = part.id,
            Plant = part.plant,
            Unit = part.unit
            // the output controls of this part:
            OutputControls = outputControlsOfThisPart.Select(outputControl => new
            {
                 // again, select only the output control properties you plan to use
                 Id = outputControl.Id,
                 Name = outputControl.Name,
                 ...
            })
            .ToList(),
            // For the Fct, take the Fct with Id equal to Part.FctId
            Fct = Fcts.Where(fct => fct.Id == part.Fct)
                      .Select(fct => new
                      {
                          // select only the Fct properties you plan to use
                          Id = fct.Id,
                          Name = fct.Name,
                          ...
                      })
                      // expect only one such Fct
                      .FirstOrDefault(),
        });
                   
