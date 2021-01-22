            string folder = Config.TestInput();
            string mask = folder + "*.*";
            var list = UT.GetAllFiles(mask, (info) => Path.GetExtension(info.Name) == ".html").ToList();
            Assert.AreNotEqual(0, list.Count);
            var lastQuarter = DateTime.Now.AddMonths(-3);
            list = UT.GetAllFiles(mask, (info) => info.CreationTime >= lastQuarter).ToList();
            Assert.AreNotEqual(0, list.Count);
