    [Test]
    public void SwitchInLambda()
    {
        TakeALambda(i => {
            switch (i)
            {
                case 2:
                    return "Smurf";
                default:
                    return "Gnurf";
            }
        });
    }
    
    public void TakeALambda(Func<int, string> func)
    {
        System.Diagnostics.Debug.WriteLine(func(2));
    }
