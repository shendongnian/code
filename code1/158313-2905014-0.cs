    public class Rows : IEnumerable<Row>
    {
        public static explicit operator MyType(IEnumerable<Row> x)
        {
            return new Rows(x); // using your constructor
        }
    }
