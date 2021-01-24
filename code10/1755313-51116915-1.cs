        class System
        {
            public string SystemName { get; set; }
            public string Location { get; set; }
            public string Type { get; set; }
        }
        static void Main(string[] args)
        {
            List<System> systemT1 = new List<System>()
            {
                new System { SystemName = "Test1", Location = "KO",Type = "1" },
                new System { SystemName = "Test2", Location = "AP",Type = "1" },
                new System { SystemName = "Test3", Location = "MP",Type = "1" }
            };
            List<System> systemT2 = new List<System>()
            {
                new System { SystemName = "Test1", Location = "KO",Type = "2" },
                new System { SystemName = "Test2", Location = "AP",Type = "2" }
            };
            //var combined = systemT1.Zip(systemT2, (SystemTy1, SystemTy2) => new { SystemTy1, SystemTy2 });
            var combined = ZipLongest(systemT1, systemT2);
            Parallel.ForEach(combined, pair =>
            {
                //var systemType1 = pair.SystemTy1;
                var systemType1 = pair.Item1;
                //ProcessType(systemType1);
                //var systemType2 = pair.SystemTy2;
                var systemType2 = pair.Item2;
                //ProcessType(systemType2);
            });
        }
