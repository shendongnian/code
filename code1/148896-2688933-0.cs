        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime[,] ranges = new DateTime[3,2];
            //Range 1 - Jan to March
            ranges[0, 0] = new DateTime(2010, 1, 1);
            ranges[0, 1] = new DateTime(2010, 3, 1);
            //Range 2 - April to July
            ranges[1, 0] = new DateTime(2010, 4, 1);
            ranges[1, 1] = new DateTime(2010, 7, 1);
            //Range 3 - March to June
            ranges[2, 0] = new DateTime(2010, 3, 1);
            ranges[2, 1] = new DateTime(2010, 6, 1);
            DateTime checkDate = new DateTime(2010, 4, 1);
            string validRanges = string.Empty;
            for (int i = 0; i < ranges.GetLength(0); i++)
            {
                if (DateWithin(ranges[i,0], ranges[i,1], checkDate))
                {
                    validRanges += i.ToString() + " ";
                }
            }
            MessageBox.Show(validRanges);
        }
        private bool DateWithin(DateTime dateStart, DateTime dateEnd, DateTime checkDate)
        {
            if (checkDate.CompareTo(dateStart) < 0 || checkDate.CompareTo(dateEnd) > 0)
            {
                return false;
            }
            return true;
        }
