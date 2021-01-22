    private double per()
    {
       double a = Convert.ToDouble(tbEnglish.Text);
       a += Convert.ToDouble(tbPhysics.Text);
       a += Convert.ToDouble(tbChemistry.Text);
       a += Convert.ToDouble(tbMaths.Text);
       double d = 500;
       double lblResult = (a / d)*100;
       return lblResult;
    }
