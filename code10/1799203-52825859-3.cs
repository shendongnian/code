           var A = new ResourceA()
            {
                ID = 15,
                Path = @"C:\Path",
                ProductID = 15001
            };
            var B = new ResourceB()
            {
                ID = 16,
                ProductID = 166101,
                Label = "Ham"
            };
            var C = new ResourceC()
            {
                ID = 188,
                Open = true,
                ProductID = 900014,
                Replacement = false,
            };
            List<IResources> resources = new List<IResources>();
            resources.Add(A);
            resources.Add(B);
            resources.Add(C);
            foreach(var r in resources)
            {
                Console.WriteLine(r.GetResource().ID);
            }
