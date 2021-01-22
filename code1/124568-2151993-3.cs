    public void AnotherClass()
    {
        IMyInterface nifty = new MyNiftyClass()
        IMyInterface odd = new MyOddClass()
        // Pass in the nifty class to do something nifty
        this.ThisMethodShowsHowItWorks(nifty);
        // Pass in the odd class to do something odd
        this.ThisMethodShowsHowItWorks(odd);
    }
