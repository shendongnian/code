    public override object GetValue(IDataParameter parameter)
    {
        if (parameter == null)
        {
            throw new ArgumentNullException(nameof(parameter));
        }
        // https://docs.oracle.com/cd/B19306_01/win.102/b14307/OracleDbTypeEnumerationType.htm
        if (parameter is OracleParameter)
        {
            switch (parameter.Value)
            {
                case OracleBinary oracleBinary:
                    // returns byte[]
                    return oracleBinary.Value;
                case OracleBoolean oracleBoolean:
                    // returns bool
                    return oracleBoolean.Value;
                case OracleDate oracleDate:
                    // returns DateTime
                    return oracleDate.Value;
                case OracleDecimal oracleDecimal:
                    // oracleDecimal.Value is Decimal, so we convert to correct type.
                    return parameter.DbType == DbType.Decimal
                        ? oracleDecimal.Value
                        : Convert.ChangeType(oracleDecimal.Value, parameter.DbType.ToType());
                case OracleIntervalDS oracleIntervalDS:
                    // returns TimeSpan
                    return oracleIntervalDS.Value;
                case OracleIntervalYM oracleIntervalYM:
                    // returns Long
                    return oracleIntervalYM.Value;
                case OracleTimeStamp oracleTimeStamp:
                    // returns DateTime
                    return oracleTimeStamp.Value;
                case OracleTimeStampLTZ oracleTimeStampLTZ:
                    // returns DateTime
                    return oracleTimeStampLTZ.Value;
                case OracleTimeStampTZ oracleTimeStampTZ:
                    // returns DateTime
                    return oracleTimeStampTZ.Value;
                default:
                    throw new NotSupportedException(
                        parameter.Value != null
                            ? parameter.Value.GetType().Name
                            : parameter.ParameterName);
            }
        }
        else
        {
            throw new NotSupportedException(parameter.GetType().Name);
        }
    }
