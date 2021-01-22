    PageData data = new PageData()
               {
                   Formats = new[]
                                 {
                                     new { ID = "string", Name = "Text" },
                                     new { ID = "int", Name = "Numeric" },
                                     new { ID = "decimal", Name = "Decimal" },
                                     new { ID = "datetime", Name = "Date/Time" },
                                     new { ID = "timespan", Name = "Stopwatch" }
                                 },
                   .............
    
               };
    return View(data);
