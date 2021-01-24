    public static string convertDateFormat(this string date)
    {
                    DateTime dateFormat = Convert.ToDateTime(date);
                    if (dateFormat != DateTime.MinValue)
                    {
                        return String.Format("{0:MM/dd/yyyy}", dateFormat);
                    }
                    else
                    {
                        return "";
                    }
    }
