    [TestFixture]
    public class CoffeeTests
    {
        [Test]
        public void Can_Create_A_Caramel_Macchiato()
        {
            var myPreferredCoffeeFromStarbucks =
                Coffee.Make.WithCream().PourIn(
                    x =>
                        {
                            x.ShotOfExpresso().AtTemperature(100);
                            x.ShotOfExpresso().AtTemperature(100).OfPremiumType();
                        }
                    ).ACupSizeInOunces(16);
            Assert.IsTrue(myPreferredCoffeeFromStarbucks.expressoExpressions[0].ExpressoShots.Count == 2);
            Assert.IsTrue(myPreferredCoffeeFromStarbucks.expressoExpressions[0].ExpressoShots.Dequeue().IsOfPremiumType == true);
            Assert.IsTrue(myPreferredCoffeeFromStarbucks.expressoExpressions[0].ExpressoShots.Dequeue().IsOfPremiumType == false);
            Assert.IsTrue(myPreferredCoffeeFromStarbucks.CupSizeInOunces.Equals(16));
        }
    }
