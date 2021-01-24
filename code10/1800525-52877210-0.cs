    private Double donationBFees = 0;
    void operatingCost(ref double afterFeesParam)
    {
        afterFeesParam = (afterFeesParam / 17);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        String donationBeforeFees;
        Double aFees;
        String totalDonationRaised;
        donationBeforeFees = donationBox.Text;
        donationBFees = System.Convert.ToDouble(donationBeforeFees);
        double afterFees = donationBFees;
        operatingCost(ref afterFees);
        afterFeesBox.Text = afterFees;
    }
