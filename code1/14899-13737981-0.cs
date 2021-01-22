    enum Seasons
    {
        Spring = 1, Summer = 2, Automn = 3, Winter = 4
    }
    public string HowYouFeelAbout(Seasons season)
    {
        switch (season)
        {
            case Seasons.Spring:
                return "Nice.";
            case Seasons.Summer:
                return "Hot.";
            case Seasons.Automn:
                return "Cool.";
            case Seasons.Winter:
                return "Chilly.";
        }
    }
