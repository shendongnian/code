      public class DataReaderInjection : KnownSourceValueInjection<IDataReader>
         {
            private IDictionary<string, string> stuff;
            public DataReaderInjection(IDictionary<string,string> stuff)
            {
              this.stuff = stuff;
            }
                        protected override void Inject(
    ...
