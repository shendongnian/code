        class TestCarModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Model { get; set; }
            public string Type { get; set; }
            public float Cost { get; set; }
        }
        private List<TestCarModel> PrepareTestData()
        {
            return new List<TestCarModel>()
            {
                new TestCarModel(){ Id = 1, Name = "Fiat", Model = "500", Type = "Kompakt", Cost = 20000 },
                new TestCarModel(){ Id = 2, Name = "Fiat", Model = "Bravo", Type = "Kompakt", Cost = 30000 },
                new TestCarModel(){ Id = 3, Name = "Opel", Model = "Astra", Type = "Sedan", Cost = 20000 },
                new TestCarModel(){ Id = 4, Name = "Honda", Model = "Civic", Type = "Hatchback", Cost = 15000 },
                new TestCarModel(){ Id = 5, Name = "Audi", Model = "A4", Type = "Sedan", Cost = 40000 },
            };
        }
