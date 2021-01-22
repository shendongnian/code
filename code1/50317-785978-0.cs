    private static SqlParameter CreateDoubleParameter(string parameterName, double value)
    {
        const double SqlFloatEpsilon = 2.23e-308;
    	SqlParameter parameter = new SqlParameter(parameterName, SqlDbType.Float);
    	parameter.Value = value > -SqlFloatEpsilon && value < SqlFloatEpsilon ? 0d : value;
    	return parameter;
    }
