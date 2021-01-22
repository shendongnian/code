    public static boolean isInteger(String in)
    {
        if (in != null)
        {
            char c;
            int i = 0;
            int l = in.length();
            if (l > 0 && in.charAt(0) == '-')
            {
                i = 1;
            }
            if (l > i)
            {
                for (; i < l; i++)
                {
                    c = in.charAt(i);
                    if (c < '0' || c > '9')
                        return false;
                }
                return true;
            }
        }
        return false;
    }
