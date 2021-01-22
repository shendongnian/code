    public void SampleMethod()
        {
            DateTime anotherDateTime = DateTime.Today.AddDays(-10);
            if ((DateTime.Now-anotherDateTime).TotalDays>10)
            {
            }
        }
        public void SampleMethod1(DateTime dateTimeNow)
        {
            DateTime anotherDateTime = DateTime.Today.AddDays(-10);
            if ((dateTimeNow - anotherDateTime).TotalDays > 10)
            {
            }
        }
