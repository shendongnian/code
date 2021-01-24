    private void Calcular_Click(object sender, EventArgs e)
    {
        // You can calculate values using Sytem.Linq extension methods
        txtMin.Text = Valores.Min().ToString();
        txtMax.Text = Valores.Max().ToString();
        txtAvg.Text = Valores.Average().ToString();
        txtTotal.Text = Valores.Sum().ToString();
    }
