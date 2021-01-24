    public class TestClass
    {
        public void Test(string kingdom, string family, string species)
        {
            ISizeCalculator calculator = null;
            if (kingdom == "A")
            {
                calculator = new ASimpleCalculation();
            }
            else if (kingdom == "B" && family == "123")
            {
                calculator = new AnotherCalculation();
            }
            else if (new string[] { "X", "Y", "Z" }.Contains(species))
            {
                calculator = new ASimpleCalculation();
            }
            // add more criteria as per your requirements
            else
            {
                calculator = new DefaultCalculation();
            }
            string result = calculator.GetSize(1, 2, 3);
        }
    }
