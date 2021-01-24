    private void btnCalc_Click(object sender, EventArgs e)
    {
        tbMax.Text = values.Max().ToString();
        tbMin.Text = values.Min().ToString();
        float sum = values.Sum();
        tbSum.Text = sum.Tosting();
        float average = sum / values.Length;
        tbAverage.Text = average.ToString();
    }
