    private void button1_Click(object sender, EventArgs e)
    {
        // Preparing PriceRangeDefinitions
        List<PriceCalculator.PriceRange> PriceRangeDefinitions = new List<PriceCalculator.PriceRange>();
        PriceRangeDefinitions.Add(new PriceCalculator.PriceRange() { MinAmount = 1, MaxAmount = 10, PricePerLicense = 50 });
        PriceRangeDefinitions.Add(new PriceCalculator.PriceRange() { MinAmount = 11, MaxAmount = 20, PricePerLicense = 40 });
        PriceRangeDefinitions.Add(new PriceCalculator.PriceRange() { MinAmount = 21, MaxAmount = 30, PricePerLicense = 30 });
        PriceRangeDefinitions.Add(new PriceCalculator.PriceRange() { MinAmount = 31, MaxAmount = 50, PricePerLicense = 20 });
        // Start the Calculation
        PriceCalculator calculator = new PriceCalculator();
        Double Total;
        List<PriceCalculator.OrderPackage> Packages =
            calculator.CalculateCheapestPrice(130, PriceRangeDefinitions, out Total);
        // Show Proof of Concept
        String ProofOfConcept = String.Empty;
        for (int i = 0; i < Packages.Count; i++)
        {
            ProofOfConcept += Packages[i].AmountOfLicenses.ToString() + " Licenses " +
                Packages[i].PriceRange.PricePerLicense.ToString() + "$ each" + Environment.NewLine;
        }
        ProofOfConcept += Environment.NewLine + "TOTAL: " + Total.ToString();
        MessageBox.Show(ProofOfConcept);
    }
