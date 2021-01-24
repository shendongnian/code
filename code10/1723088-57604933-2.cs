        static void Main()
        {
            // example data
            var warehouses = new List<Warehouse>
            {
                new Warehouse { WarehouseName = "NY1", Quantity = 10 },
                new Warehouse { WarehouseName = "NY2", Quantity = 100 }
            };
            var parts = new List<Part> 
            { 
                 new Part { PartNumber = "1", Description = "Hammer", Warehouses = warehouses } 
            };
            // query
            var result =
                parts
                .Select(@"new ( 
                   PartNumber,
                   Description,
                   Warehouses.Select(WarehouseName).ToList() as WarehouseNames
                )");
        }
