    private static IEnumerable<CartoonFigure> GetFigures(CartoonStory story, Sex preferredSex)
    {
        var result = story.StoryTellerFigures.Where(cf => cf.Sex == preferredSex);
        if (!result.Any())
        {
            result = story.StoryTellerFigures;
        }
        return result;
    }
