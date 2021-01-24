    var listOfMonths = MyCollection.GroupBy(obj => obj.Month).Select(groupingObj => new
                {
                    month = groupingObj.Key,
                    yearSum = groupingObj.GroupBy(x => x.Year).Select(newGroup => newGroup.Sum(s => s.Amount))
                });
