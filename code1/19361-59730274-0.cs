            public Animal Animal { get; set; }
            ...
            var animalName = Animal switch
            {
                Cat cat => "Tom",
                Mouse mouse => "Jerry",
                _ => "unknown"
            };
