    //String.Format("{0:HH:mm}", dt);  // where dt is a DateTime variable
    public static string FormatearHoraA24(DateTime? fechaHora)
    {
        if (!fechaHora.HasValue)
            return "";
        return retornar = String.Format("{0:HH:mm}", (DateTime)fechaHora);
    }
