    public partial class Vw_DD_MM
    {
        public int MMID { get; set; }
        public string MiladiDate { get; set; }
        public string PersianDate
        {
            get
            {
                DateTime englishDate = DateTime.Parse(MiladiDate);
                PersianCalendar pc = new PersianCalendar();
                return string.Format("{0}/{1}/{2}", pc.GetYear(englishDate), pc.GetMonth(englishDate).ToString("00"), pc.GetDayOfMonth(englishDate).ToString("00"));
            }
        }
    }
