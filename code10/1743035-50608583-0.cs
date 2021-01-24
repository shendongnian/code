    var result = items.GroupBy(i => new { i.Id, i.Name })
                      .Select(g => new Result
                      {
                          Id = g.Key.Id,
                          Name = g.Key.Name,
                          TagIds = g.Select(i => i.TagId).ToList(),
                          DepartmentId = g.FirstOrDefault(i => i.DepartmentId != null)?.DepartmentId,
                          Codes = g.Select(i => i.Code).ToList();
                      });
