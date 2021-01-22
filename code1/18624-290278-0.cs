    public static double GetCurrentMilli()
            {
               DateTime Jan1970 = new DateTime(1970,1, 1);
               TimeSpan javaSpan = DateTime.Now.Subtract(Jan1970);
               return javaSpan.TotalMilliseconds;
            }
