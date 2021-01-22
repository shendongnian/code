    public class SalaryFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
             return (formatType == typeof(ICustomFormatter)) ? new
             SalaryFormatter () : null;
        }
    
        public string Format(string format, object o, IFormatProvider formatProvider)
        {
            if (o.GetType().Equals(typeof(Salary)))
            {
                return o.ToString();
    
                Salary salary = (Salary)o;
                switch (salary)
                {
                    case Salary.Low:
                         return "0 - 25K";
                    case Salary.Mid:
                         return "25K - 100K";
                    case Salary.High:
                         return "100K+";
                    default:
                         return salary.ToString();
                }
            }
    
    	return o.ToString();
        }
    }
