    private void Calcular_Click(object sender, EventArgs e)
    {
        // Or you can do it the long way. First start with default values:
        float min = Single.MaxValue;
        float max = Single.MinValue;
        float total = 0;
        // Then go through each item in the array 
        // and update the values above if necessary
        foreach (float item in Valores)
        {
            if (item < min) min = item;
            if (item > max) max = item;
            total = total + item;
        }
        // Calculate average last since we need the total first
        float avg = total / Valores.Length;
        // Update the textboxes with these values:
        txtMin.Text = min.ToString();
        txtMax.Text = max.ToString();
        txtAvg.Text = avg.ToString();
        txtTotal.Text = total.ToString();
    }
