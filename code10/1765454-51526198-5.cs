    private void Okay_Click(object sender, EventArgs e)
    {
        Class1 Co = new Class1();
        var numbers=input1.Text.Split('+');
        Co.NumOne= double.parse(numbers[0]);
        Co.NumTwo= double.parse(numbers[1]);
        MessageBox.Show(Co.Multiply().ToString());
    }
