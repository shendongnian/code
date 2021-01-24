    private void Okay_Click(object sender, EventArgs e)
    {
        Class1 Co = new Class1();
        Co.NumOne= double.parse(input1.Text);
        Co.NumTwo= double.parse(input2.Text);
        MessageBox.Show(Co.Multiply().ToString());
    }
