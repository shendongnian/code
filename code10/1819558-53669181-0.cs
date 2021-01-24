	//using System.Data.SqlTypes;
	//using System.Numerics; //also needs an assembly reference to System.Numerics.dll
	public static class BigIntegerExtensions
	{
		public static SqlDecimal ToSqlDecimal(this BigInteger bigint)
		{
			SqlDecimal result = 0;
            var longMax = (SqlDecimal)long.MaxValue; //cache the converted value to minimise conversions
			var longMin = (SqlDecimal)long.MinValue;
			while (bigint > long.MaxValue)
			{
				result += longMax;
				bigint -= long.MaxValue;
			}
			while (bigint < long.MinValue)
			{
				result += longMin;
				bigint -= long.MinValue;
			}
			return result + (SqlDecimal)(long)bigint;
		}
	}
