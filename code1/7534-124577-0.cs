        public void Test()
        {
            int? x = null;
            int a = x.IfNotNull(z => z.Value + 1, 3);
            int b = x.IfNotNull(z => z.Value + 1);
        }
