    public interface IDataFactory
    {
        DataTable Create(Type t);
    }
    public class DataFactory : IDataFactory
    {
        public DataTable Create(Type t)
        {
            if (t == typeof(FooData))
            {
                return new List<FooData>()
                {
                    new FooData() {Id = 0, AlbumName = "Greatest Hits", IsPlatinum = true},
                    new FooData() {Id = 1, AlbumName = "Worst Hits", IsPlatinum = false}
                }.ToDataTable();
            }
            if (t == typeof(BarData))
            {
                return new List<BarData>()
                {
                    new BarData() {Id = 1, PenPointSize = 0.7m, InkColor = "Blue"},
                    new BarData() {Id = 2, PenPointSize = 0.5m, InkColor = "Red"}
                }.ToDataTable();
            }
            return new List<dynamic>().ToDataTable();
        }
    }
