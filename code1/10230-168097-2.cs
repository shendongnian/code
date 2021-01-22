        public void Test()
        {
            ComplexCalculationTest myTestObject = new ComplexCalculationTest();
            myTestObject.SetFavoriteNumber(3);
            ComplexCalculation myObject = myTestObject;
            if (myObject.FavoriteNumber == 3)
                Console.WriteLine("Win!");
        }
