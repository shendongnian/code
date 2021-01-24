    public static class AgeGroups {
        public static Dictionary<string, int> Items = new Dictionary<string, int>(){
            { "Modern (Less than 10 years old)", 1 },
            { "Retro (10 - 20 years old)", 2 },
            { "Vintage(20 - 70 years old)", 3 },
            { "Antique(70+ years old)", 4 }
        };
    
        public static IQueryable<ProductDTO> FilterAgeByGroup(IQueryable<ProductDTO> query, List<string> filters) {
            var currentYear = DateTime.UtcNow.Year;
    
            var pred = PredicateBuilder.New<ProductDTO>();
            foreach (var fs in filters) {
                if (Items.TryGetValue(fs, out var fv)) {
                    switch (fv) {
                        case 1:
                            pred = pred.Or(p => currentYear-p.YearManufactured < 10);
                            break;
                        case 2:
                            pred = pred.Or(p => 10 <= currentYear-p.YearManufactured && currentYear-p.YearManufactured  <= 20);
                            break;
                        case 3:
                            pred = pred.Or(p => 20 <= currentYear-p.YearManufactured && currentYear-p.YearManufactured  <= 70);
                            break;
                        case 4:
                            pred = pred.Or(p => 70 <= currentYear-p.YearManufactured);
                            break;
                    }
                }
            }
    
            return query.Where(pred);
        }
    }
