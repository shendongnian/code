    private BonusCalculator Calculator { get; set; }
    public void GiveBonus()
    {
       Bonus = Calculator.CalculateBonus(this)
    }
