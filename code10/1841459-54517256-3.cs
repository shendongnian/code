    static Ad Select(this IReadOnlyList<Ad> ads)
    {
        var range = ads.ToRange().ToList();
        int selectedIndex = rnd.Next(range.Count);
        return ads[selectedIndex];
    }
    static IEnumerable<Ad> SelectAds(this IEnumerable<Ad> ads, int selectCount)
    {
        for (int i=0; i<selectCount; ++i)
        {
            var selectedAd = ads.Select();
            yield return selectedAd;
            selectedAd.IsDisplayed = true; // to make sure it is not selected again
        }
    }
