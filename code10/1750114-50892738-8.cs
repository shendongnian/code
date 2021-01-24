           private List<Meb> GroupIdenticalMeb(List<Meb> mebInput)
            {
                return mebInput.GroupBy(x => new { number = x.Number, len = x.Length }).Select(x => new Meb()
                {
                    ID = x.First().ID,
                    Number = x.Key.number,
                    Length = x.Key.len,
                    Quantity = x.Sum(y => y.Quantity)
                }).ToList();
            }
