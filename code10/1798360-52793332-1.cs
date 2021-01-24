    private void CalculatePrice()
    {
        decimal price = 0M;
        if (radChocolate.Checked) price += 75M;
        if (radVanilla.Checked) price += 65M;
        if (radStrawberry.Checked) price += 55M;
    
        if (radSmall.Checked) price += 20M;
        if (radLarge.Checked) price += 30M;
    
        if (chkChocoChips.Checked) price += 5M;
        if (chkCookieCandy.Checked) price += 4M;
        if (chkNuts.Checked) price += 3M;
        if (chkFreshFruits.Checked) price += 2M;
    
        txtPrice.Text = price.ToString("C");
    }
