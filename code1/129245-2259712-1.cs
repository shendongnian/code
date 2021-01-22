    public void FeedHorse()
    {
        using (var apple = appleFactory())
        {
            horse.Eat(apple.Value);
        }
    }
