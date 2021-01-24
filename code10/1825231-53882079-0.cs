    [StepArgumentTransformation("(.*) as (.*)")]
    public int GetOnces(string onces, string times)
    {
        return 1 * int.Parse(times);
    }
    [Given(@"user enter (.*)")]
    public void GivenUserEnterOnce(int num)
    {
        Assert.Equal(2, num);
    }
