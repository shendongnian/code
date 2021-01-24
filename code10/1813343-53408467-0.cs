    public class ReportCard
        {
            public string Subject
            {
                get;
                set;
            }
            public int Mark
            {
                get;
                set;
            }
        }
      List<ReportCard> ReportCard = JsonConvert.DeserializeObject<List<ReportCard>> 
      (json);
