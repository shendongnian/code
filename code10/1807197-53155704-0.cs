    List<History> a = getTodayData();
     Today t = new Today
               {
                Clicks = a.Sum(h => h.Clicks),
                Views=a.Sum(h=>h.Views),
                Points=a.Sum(h=>h.Points)
            };
