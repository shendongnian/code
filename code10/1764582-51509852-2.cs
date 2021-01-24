    abstract class QueryExpression
    {
        public string Operator { get; set; }
    }
    class CompositeExpression: QueryExpression  // AND, OR
    {
        public List<QueryExpression> SubExpressions { get; set; }
        public override string ToString()
        {
            return "(" + string.Join(" " + Operator + " ", SubExpressions) + ")";
        }
    }
    class BinaryExpression: QueryExpression  // EQ
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public override string ToString()
        {
            return Value1 + " " + Operator + " " + Value2;
        }
    }
