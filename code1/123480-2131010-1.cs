    public decimal AveragePercentage()
    {
        int sum = int.Parse(tbEnglish.Text) +
                  int.Parse(tbUrdu.Text) +
                  int.Parse(tbPhysics.Text) +
                  int.Parse(tbChemistry.Text) +
                  int.Parse(tbMaths.Text);
        return sum / 500m;
    }
