    static class MyExt {
    //Self Check 
     public static void SC(this string you,ref string me)
        {
            me = me ?? you;
        }
    }
