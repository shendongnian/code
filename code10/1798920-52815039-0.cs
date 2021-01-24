    private void Button1_Click(object sender, EventArgs e)
    {
        elementos[0] = TextBox1.Text;
        elementos[1] = TextBox2.Text;
        elementos[2] = TextBox3.Text;
        elementos[3] = TextBox4.Text;
        elementos[4] = TextBox5.Text;
        Bubblesort();
        for(int i=0;i<elementos.Length;i++)
        {
            lbOrdenada.Items.Add(elementos[i]);
        }
    }
