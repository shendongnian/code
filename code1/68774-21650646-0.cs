    public static DateTime? ToDateTime(this Element e)
        {
            if (e == null)
                return null;
    
            if (string.IsNullOrEmpty(e.Value))
                return null;
            else
                return DateTime.Parse(e.Value);
        }
