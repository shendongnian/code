        public void TestMethod1 ( )
        {
            DateTime date = DateTime.Now;
            DateTime friday = date.AddDays( (int)DayOfWeek.Friday - (int)date.DayOfWeek );
            Console.WriteLine( friday.ToString( ) );
        }
