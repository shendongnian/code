        private void btnClick_Click(object sender, EventArgs e)
        {
            //DateTime theFromDate = dateTimePicker1.Value;
            DateTime theToDate = dateTimePicker2.Value;
            List<DateRange> lstRange1 = GetDateRange();
            List<DateRange> lstRange2 = GetDateRange();
            var result = lstRange1.Any(x => x.date >= theToDate && lstRange2.Any(y => y.date < theToDate));
            if (result)
            {
                MessageBox.Show(theToDate.ToString("dd-MMM-yyyy") + " in the date range!");
            }
            else
            {
                MessageBox.Show(theToDate.ToString("dd-MMM-yyyy") + " not in the date range!");
            }
        }
        public List<DateRange> GetDateRange()
        {
            List<DateRange> lstDate = new List<DateRange>();
            lstDate.Add(new DateRange { date = Convert.ToDateTime("10-Aug-2018") });
            lstDate.Add(new DateRange { date = Convert.ToDateTime("11-Aug-2018") });
            lstDate.Add(new DateRange { date = Convert.ToDateTime("12-Aug-2018") });
            lstDate.Add(new DateRange { date = Convert.ToDateTime("13-Aug-2018") });
            return lstDate;
        }
