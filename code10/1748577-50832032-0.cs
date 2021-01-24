    double totalfees = Convert.ToDouble(textBox12.Text.ToString().Trim());
    double paidfees = Convert.ToDouble(textBox13.TextToString().Trim());
    double pendingfees = totalfees - paidfees;
    
    label20.Text = pendingfees.ToString();
