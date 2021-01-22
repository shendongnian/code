    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<IRange<int>> enumRange1 = new IRange<int>[0];
            IEnumerable<IRange<int, float>> enumRange2 = new IRange<int, float>[0];
    
            IEnumerable<IRange<int, float, string>> enumRange3 = new TestRange<int, float, string>[]
            {
                new TestRange<int, float, string> { Begin = 10, End = 20, Data = 3.0F, MoreData = "Hello" },
                new TestRange<int, float, string> { Begin = 5, End = 30, Data = 3.0F, MoreData = "There!" }
            };
    
            enumRange1.RangeExtensions().Slice();
            enumRange2.RangeExtensions().Slice();
            enumRange3.RangeExtensions().Slice();
        }
    }
    
    public interface IRange<T> where T : IComparable<T>
    {
        int Begin { get; set; }
        int End { get; set; }
    }
    
    public interface IRange<T, TData> : IRange<T> where T : IComparable<T>
    {
        TData Data { get; set; }
    }
    
    public interface IRange<T, TData, TMoreData> : IRange<T, TData> where T : IComparable<T>
    {
        TMoreData MoreData { get; set; }
    }
    
    public class TestRange<T, TData, TMoreData> : IRange<T, TData, TMoreData>
        where T : IComparable<T>
    {
        int m_begin;
        int m_end;
        TData m_data;
        TMoreData m_moreData;
    
        #region IRange<T,TData,TMoreData> Members
        public TMoreData MoreData
        {
            get { return m_moreData; }
            set { m_moreData = value; }
        }
        #endregion
    
        #region IRange<T,TData> Members
        public TData Data
        {
            get { return m_data; }
            set { m_data = value; }
        }
        #endregion
    
        #region IRange<T> Members
        public int Begin
        {
            get { return m_begin; }
            set { m_begin = value; }
        }
    
        public int End
        {
            get { return m_end; }
            set { m_end = value; }
        }
        #endregion
    }
    
    public static class RangeExtensionCasts
    {
        public static RangeExtensions<T1> RangeExtensions<T1>(this IEnumerable<IRange<T1>> source)
            where T1 : IComparable<T1>
        {
            return new RangeExtensions<T1>(source);
        }
    
        public static RangeExtensions<T1> RangeExtensions<T1, T2>(this IEnumerable<IRange<T1, T2>> source)
            where T1 : IComparable<T1>
        {
            return Cast<T1, IRange<T1, T2>>(source);
        }
    
        public static RangeExtensions<T1> RangeExtensions<T1, T2, T3>(this IEnumerable<IRange<T1, T2, T3>> source)
            where T1 : IComparable<T1>
        {
            return Cast<T1, IRange<T1, T2, T3>>(source);
        }
    
        private static RangeExtensions<T1> Cast<T1, T2>(IEnumerable<T2> source)
            where T1 : IComparable<T1>
            where T2 : IRange<T1>
        {
            return new RangeExtensions<T1>(
                Enumerable.Select(source, (rangeDescendentItem) => (IRange<T1>)rangeDescendentItem));
        }
    }
    
    public class RangeExtensions<T>
        where T : IComparable<T>
    {
        IEnumerable<IRange<T>> m_source;
    
        public RangeExtensions(IEnumerable<IRange<T>> source)
        {
            m_source = source;
        }
    
        public void Slice()
        {
            // your slice logic
    
            // to ensure the deferred execution Cast method is working, here I enumerate the collection
            foreach (IRange<T> range in m_source)
            {
                Console.WriteLine("Begin: {0} End: {1}", range.Begin, range.End);
            }
        }
    }
