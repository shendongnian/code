    public class ListSelectionFormatter : IFormatProvider, ICustomFormatter
    {
        #region IFormatProvider Members
        public object GetFormat(Type formatType)
        {
            if (typeof(ICustomFormatter).IsAssignableFrom(formatType))
                return this;
            else
                return null;
        }
        #endregion
        #region ICustomFormatter Members
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string[] values = format.Split('|');
            if (values == null || values.Length == 0)
                throw new FormatException("The format is invalid.  At least one value must be specified.");
            if (arg is int)
                return values[(int)arg];
            else if (arg is Random)
                return values[(arg as Random).Next(values.Length)];
            else if (arg is ISelectionPicker)
                return (arg as ISelectionPicker).Pick(values);
            else
                throw new FormatException("The argument is invalid.");
        }
        #endregion
    }
    public interface ISelectionPicker
    {
        string Pick(string[] values);
    }
    public class RandomSelectionPicker : ISelectionPicker
    {
        Random rng = new Random();
        public string Pick(string[] values)
        {
            // use whatever logic is desired here to choose the correct value
            return values[rng.Next(values.Length)];
        }
    }
    class Stuff
    {
        public static void DoStuff()
        {
            RandomSelectionPicker picker = new RandomSelectionPicker();
            string result = string.Format(new ListSelectionFormatter(), "I am feeling {0:funky|great|lousy}.  I should eat {1:a banana|cereal|cardboard}.", picker, picker);
        }
    }
