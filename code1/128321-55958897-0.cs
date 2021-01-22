            var yesterday = DateTime.Today.AddDays(-1);
            var today = DateTime.Today;
            var tomorrow = DateTime.Today.AddDays(1);            
            var vm = new Model()
            {
                Yesterday = _context.Table.Where(x => x.From <= yesterday && x.To >= yesterday).ToList(),
                Today = _context.Table.Where(x => x.From <= today & x.To >= today).ToList(),
                Tomorrow = _context.Table.Where(x => x.From <= tomorrow & x.To >= tomorrow).ToList()
            };
