     var result = testq
                 .GroupBy(p => p.QuestionId)
                 .Select(p => 
                  {
                     var grouped = p.ToList(); //Get the groupBy list
                     TestQuestion testQuestion = grouped.FirstOrDefault(x => x.SelectedAnswerId.HasValue); //Get anything with AnswerId
                     return testQuestion ?? grouped.FirstOrDefault(); //If not not available with Answer then get the First or Default value
                  })
                  .ToList();
