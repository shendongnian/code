        public static string MethodGBSizeDueEstimate()
        {
            DateTime dtDueTimeRounded = new DateTime();
            DateTime dtDueTimeNow = DateTime.Now;
            DateTime dtDueTime = new DateTime();
            decimal dFileSize = Convert.ToDecimal(txtFileSize.Text);
            if (dFileSize > 2 && dFileSize <= 7)
            {
                if (dtDueTimeNow.Minute > 30)
                {
                    dtDueTime = dtDueTimeNow.AddHours(9);
                    dtDueTimeRounded = Convert.ToDateTime(dtDueTime.ToString("MM/dd/yyyy hh:00 tt")); 
                }
                else if (dtDueTimeNow.Minute < 30)
                {
                    dtDueTime = dtDueTimeNow.AddHours(8);
                    dtDueTimeRounded = Convert.ToDateTime(dtDueTime.ToString("MM/dd/yyyy hh:00 tt"));
                }
                else
                {
                    dtDueTime = dtDueTimeNow.AddHours(8);
                    dtDueTimeRounded = Convert.ToDateTime(dtDueTime.ToString("MM/dd/yyyy hh:30 tt"));
                }
            }
            return Convert.ToString(dtDueTimeRounded);
        }
        
        private void btnGenerateEboard_Click(object sender, EventArgs e)
        {
            string stDueTime;
            if (rbtnGB.Checked)
            {
                stDueTime = MethodGBSizeDueEstimate();
            }
            if (rbtnNative2Rel.Checked)
            {
                txtEboardText.AppendText(Environment.NewLine + stDueTime);
            }
        }
