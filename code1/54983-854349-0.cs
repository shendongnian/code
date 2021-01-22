        [Guid("<PUT-GUID-HERE-1>")]
        [ComVisible(true)]
        interface IFoo
        {
            void DoFoo();
        }
        [Guid("<PUT-GUID-HERE-2>")]
        [ComVisible(true)]
        [ProgId("ProgId.Foo")]
        class Foo : IFoo
        {
            public void DoFoo()
            {
            }
        }
