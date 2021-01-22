    class ExampleFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return this;
        }
    
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // make this more robust
            JobDetails job = (JobDetails)arg;
    
            switch (format)
            {
                case "User":
                {
                    return job.User;
                }
                default:
                {
                    // this should be replaced with logic to cover the other formats you need
                    return String.Empty;
                }
            }
        }
    }
