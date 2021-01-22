    MockedDiceRoller diceRoller = new MockedDiceRoller();
    diceRoller.Value = 20;
    Dice.SetDiceRoller(diceRoller);
    
    Dice.Roll(1, 20);
    Assert.IsTrue(Dice.IsCritical);
