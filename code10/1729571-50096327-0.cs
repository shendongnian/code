      public static void UseLCCors(this List<LCCorsOptions> list, Action<LCCorsOptions> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }
