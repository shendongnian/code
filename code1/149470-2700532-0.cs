    public static class DefectExtensions
    {
         public static DateTime SubmitDateAsDate( this IDefectProperties source )
         {
                return DateTime.Parse( source.SubmitDate );
         }
         public static void SetSubmitDateAsDate( this IDefectProperties source, DateTime date )
         {
               source.SubmitDate = date.ToString();
         }
    }
