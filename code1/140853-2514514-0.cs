    public String formatAllowed(String allowedFormats)
    {
        String[] formats = allowedFormats.Split('|');
    
        if (formats.Length == 1)
            return formats[0];
    
        StringBuilder sb = new StringBuilder(formats[0]);
    
        for (int i = 1; i < formats.Length - 1; i++)
        {   
            sb.Append(",");
            sb.Append(formats[i]);
        }
    
        sb.Append(" and ");
        sb.Append(formats[formats.Length - 1]);
        return sb.ToString();
    }
