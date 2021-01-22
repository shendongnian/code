        //When Expression is Number
        public static double? isNull(double? Expression, double? Value)
        {
            if (Expression ==null)
            {
                return Value;
            }
            else
            {
                return Expression;
            }
        }
        //When Expression is string (Can not send Null value in string Expression
        public static string isEmpty(string Expression, string Value)
        {
            if (Expression == "")
            {
                return Value;
            }
            else
            {
                return Expression;
            }
        }
