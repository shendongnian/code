    public class BitwiseFlags : LogicalExpression
    {
        private BitwiseFlags( string propertyName, object value, string op ) :
            base( new SimpleExpression( propertyName, value, op ),
            Expression.Sql( "?", value, NHibernateUtil.Enum( value.GetType() ) ) )
        {
        }
        protected override string Op
        {
            get { return "="; }
        }
        public static BitwiseFlags IsSet(string propertyName, Enum flags)
        {
            return new BitwiseFlags( propertyName, flags, " & " );
        }
    }
