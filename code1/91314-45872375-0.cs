    public static String toProperName(String name)
    {
        if (name != null)
        {
            if (name.Length >= 2 && name.ToLower().Substring(0, 2) == "mc")  // Changes mcdonald to "McDonald"
                return "Mc" + Regex.Replace(name.ToLower().Substring(2), @"\b[a-z]", m => m.Value.ToUpper());
    
            if (name.Length >= 3 && name.ToLower().Substring(0, 3) == "van")  // Changes vanwinkle to "VanWinkle"
                return "Van" + Regex.Replace(name.ToLower().Substring(3), @"\b[a-z]", m => m.Value.ToUpper());
    
            return Regex.Replace(name.ToLower(), @"\b[a-z]", m => m.Value.ToUpper());  // Changes to title case but also fixes 
                                                                                       // appostrophes like O'HARE or o'hare to O'Hare
        }
                        
        return "";
    }
