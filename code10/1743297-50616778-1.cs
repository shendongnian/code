    public static class ExensionMethod
    {
        public static bool Contains(this string input, BeadColor cColor)
        {
            string[] str = { "P", "B", "T" };
    
            if (cColor == BeadColor.BLUE)
                return input.Contains(str[0]);
    
            if (cColor == BeadColor.RED)
                return input.Contains(str[1]);
    
            if (cColor == BeadColor.GREEN)
                return input.Contains(str[2]);
    
            return false;
        }
    }
