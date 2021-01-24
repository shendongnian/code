    private void button1_Click(object sender, EventArgs e)
    {
        double X_Last = 0.0, Y_Last = 0.0, Z_Last = 0.0;
        double MD = 0.0;
        var lines = File.ReadLines(Survey_File.Text).Select(l => l.Split(','));
        foreach(var line in lines)
        {
            double X = double.Parse(line[1].Trim());
            double Y = double.Parse(line[2].Trim());
            double Z = double.Parse(line[3].Trim());
            double XDiff = X - X_Last;
            double YDiff = Y - Y_Last;
            double ZDiff = Z - Z_Last;
            double increment = Math.Sqrt((XDiff * XDiff) + (YDiff * YDiff) + (ZDiff * ZDiff));
            MD =+ increment;
            X_Last = X;
            Y_Last = Y;
            Z_Last = Z;
            Console.WriteLine(MD.ToString()); // Error Here
        }
        Console.ReadLine();
        MessageBox.Show("Measured Depth = " + Convert.ToString(MD));
    }
