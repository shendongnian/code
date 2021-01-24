    private void ShowForm2Button_Click(object sender, EventArgs e)
    {
        Form2 form2 = new Form2();
        form2.ValuesChanged += form2_ValuesChanged;
        form2.Show();
    }
    void form2_ValuesChanged(object sender, ChartValuesChangedEventArgs e)
    {
        // Update the chart values here
        Debug.Print(e.Value1.ToString());
        Debug.Print(e.Value2);
    }
