        [Import]
        public Helper MyHelper { get; set; }
        public void Run()
        {
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            var batch = new CompositionBatch();
            batch.AddPart(this);
            container.Compose(batch);
            logger.Log("hello");
            logger.Log(MyHelper.TimesTwo(15).ToString());
            Console.ReadKey();
        }
