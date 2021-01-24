        private DateTime examinationDate;
        public DateTime ExaminationDate
        {
            get { return ConvertToLocalDateTime(examinationDate); }
            set { examinationDate = value; }
        }
        public DateTime ConvertToLocalDateTime(DateTime examinationDate)
        {
            string timezone = TimeZone.CurrentTimeZone.StandardName;
            TimeZoneInfo infotime = TimeZoneInfo.FindSystemTimeZoneById(timezone);
            DateTime thisDate = TimeZoneInfo.ConvertTimeFromUtc(examinationDate, infotime);
            return thisDate;
        }
