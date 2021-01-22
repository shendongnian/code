    public static DateTime GetSubmitDateAsDate(this IDefectProperties defectProperties) {
        return DateTime.Parse(defectProperties.SubmitDate);
    }
    public static void SetSubmitDateAsDate(this IDefectProperties defectProperties, DateTime dateTime) {
        defectProperties.SubmitDate = dateTime.ToString();
    }
