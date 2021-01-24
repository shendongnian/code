       this.repository.ListAsync().Where(u => u.FuelSummary.Any(e => e.FuelId == 1)
                .Select(x => new
                {
                    x,
                    Fuels = x.FuelSummary.Where(e => e.FuelId == 1)
                });
