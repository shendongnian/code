      public static void Show()
             {
            for (int j = 0; j < 10; ++j)
            {
                a[j]?.Reveal();//Or if(a[j] != null)
            }
        }
