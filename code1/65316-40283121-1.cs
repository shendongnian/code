    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            float Stukprijs;
            float Aantal;
            private void label2_Click(object sender, EventArgs e)
            {
    
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                MessageBox.Show("In de eersre textbox staat een geldbedrag." + Environment.NewLine + "In de tweede textbox staat een aantal." + Environment.NewLine + "Bereken wat er moetworden betaald." + Environment.NewLine + "Je krijgt 15% korting over het bedrag BOVEN de 100." + Environment.NewLine + "Als de korting meer dan 10 euri is," + Environment.NewLine + "wordt de korting textbox lichtgroen");
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                errorProvider1.Clear();
                errorProvider2.Clear();
                if (float.TryParse(textBox1.Text, out Stukprijs))
                {
                    if (float.TryParse(textBox2.Text, out Aantal))
                    {
                        float Totaal = Stukprijs * Aantal;
                        string Output = Totaal.ToString();
                        textBox3.Text = Output;
                        if (Totaal >= 100)
                        {
                            float korting = Totaal - 100;
                            float korting2 = korting / 100 * 15;
                            string Output2 = korting2.ToString();
                            textBox4.Text = Output2;
                            if (korting2 >= 10)
                            {
                                textBox4.BackColor = Color.LightGreen;
                            }
                            else
                            {
                                textBox4.BackColor = SystemColors.Control;
                            }
                        }
                        else
                        {
                            textBox4.Text = "0";
                            textBox4.BackColor = SystemColors.Control;
                        }
                    }
                    else
                    {
                        errorProvider2.SetError(textBox2, "Aantal plz!");
                    }
                    
                }
                else
                {
                    errorProvider1.SetError(textBox1, "Bedrag plz!");
                    if (float.TryParse(textBox2.Text, out Aantal))
                    {
    
                    }
                    else
                    {
                        errorProvider2.SetError(textBox2, "Aantal plz!");
                    }
                }
                
            }
    
            private void BTNwissel_Click(object sender, EventArgs e)
            {
                //LL, LU, LR, LD.
                Color c = LL.BackColor;
                LL.BackColor = LU.BackColor;
                LU.BackColor = LR.BackColor;
                LR.BackColor = LD.BackColor;
                LD.BackColor = c;
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                MessageBox.Show("zorg dat de kleuren linksom wisselen als je op de knop drukt.");
            }
        }
    }
