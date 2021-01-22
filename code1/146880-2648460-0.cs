    private void button1_Click(object sender, EventArgs e) {
      string txt = "";
      for (int ix = 1; ix <= 4; ++ix) {
        var nud = Controls["numericUpDown" + ix] as NumericUpDown;
        int hex = (int)nud.Value;
        txt += hex.ToString("X2");
      }
      textBox1.Text = txt;
    }
