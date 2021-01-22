    public static class Ado {
        public static void SetParameterValue<T>( IDataParameter parameter, T? value ) where T : struct {
            if ( null == value ) { parameter.Value = DBNull.Value; }
            else { parameter.Value = value.Value; }
        }
        public static void SetParameterValue( IDataParameter parameter, string value ) {
            if ( null == value ) { parameter.Value = DBNull.Value; }
            else { parameter.Value = value; }
        }
    }
