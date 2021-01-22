    public class MyConverter : IMultiValueConverter
    {
        public object Convert(...)
        {
            object content = values[0];
            double actualWidth = (double)values[1];
            double desiredWidth = (double)values[2];
    
            if (desiredWidth > actualWidth)
            {
                return "######";
            }
    
            return content;
        }
    }
