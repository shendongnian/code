        protected void Page_Load(object sender, EventArgs e)
        {
            SecondsSinceNow(new DateTime(2010, 1, 1, 0, 0, 0));
        }
        private double SecondsSinceNow(DateTime compareDate)
        {
            System.TimeSpan timeDifference = DateTime.Now.Subtract(compareDate);
            return timeDifference.TotalSeconds;
        }
