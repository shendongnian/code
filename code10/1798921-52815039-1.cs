    private void Button1_Click(object sender, EventArgs e)
    {
        elementos[0] = Convert.ToInt32(TextBox1.Text);
        elementos[1] = Convert.ToInt32(TextBox2.Text);
        elementos[2] = Convert.ToInt32(TextBox3.Text);
        elementos[3] = Convert.ToInt32(TextBox4.Text);
        elementos[4] = Convert.ToInt32(TextBox5.Text);
        Bubblesort();
        for(int i=0;i<elementos.Length;i++)
        {
            lbOrdenada.Items.Add(elementos[i]);
        }
    }
