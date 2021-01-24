    private void button1_Click(object sender, EventArgs e)
    {
        string s = "5432.2";
        if(TryParseToPermille(s, CultureInfo.InvariantCulture, out int promille))
        {
            MessageBox.Show(promille.ToString());
        }
    }
