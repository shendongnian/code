        [TestMethod]
        public void TestMethod_DefaultifEmpty()
        {
            ListA = new List<A>()
            {
                new A { Id=1, Value="111" },
                new A { Id=2, Value="222" },
            };
            ListC = new List<C>()
            {
                new C { Id=1,  A_Id=1 }
            };
            Assert.AreEqual(2, MyMethod().Count());
        }
        public List<A> ListA { get;  set; }
        public List<C> ListC { get; set; }
        public IEnumerable<A_DTO> MyMethod() =>
                        from a in ListA
                        join c in ListC
                        on a.Id equals c.A_Id into g
                        from cc in g.DefaultIfEmpty()
                        select new A_DTO
                        {
                            Id = a.Id,
                            Value = a.Value,
                            //BoolProp = cc.A_Id != null
                            BoolProp = cc != null // replace by previous line to see the difference
                        };
