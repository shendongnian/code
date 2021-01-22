    public decimal AveragePercentage()
    {
        decimal sum = decimal.Parse(tbEnglish.Text) +
                      decimal.Parse(tbUrdu.Text) +
                      decimal.Parse(tbPhysics.Text) +
                      decimal.Parse(tbChemistry.Text) +
                      decimal.Parse(tbMaths.Text);
        return sum / 500m;
    }
