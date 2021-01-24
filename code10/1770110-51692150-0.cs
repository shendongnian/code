    using System.Linq;
    ...
    private void button7_Click(object sender, EventArgs e)
    {
       decimal[] rates = { 1.60m, 1.65m, 1.62m, 1.55m, 1.68m, 1.58m };
       txtAvg.Text = rates.Max();
       txtHighest.Text = rates.Min();
       txtLowest.Text = rates.Average();
    }
