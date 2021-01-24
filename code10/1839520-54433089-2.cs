    private void btnAdd_Click(object sender, EventArgs e)
    {
        decimal Score = Convert.ToDecimal(txtScore.Text);
        
        Total += Score;
        Count++;
        decimal Average = Total/Count;
        txtCount.Text = Count.ToString();
        txtTotal.Text = Total.ToString();
        txtAverage.Text = Average.ToString();
    }
