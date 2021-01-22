    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            Dictionary<string, string> slova = new Dictionary<string, string>();
    
            public Form1()
            {
                InitializeComponent();
                slova.Add("Љ", "Lj");
                slova.Add("Њ", "Nj");
                slova.Add("Џ", "Dž");
                slova.Add("љ", "lj");
                slova.Add("њ", "nj");
                slova.Add("џ", "dž");
                slova.Add("а", "a");
                slova.Add("б", "b");
                slova.Add("в", "v");
                slova.Add("г", "g");
                slova.Add("д", "d");
                slova.Add("ђ", "đ");
                slova.Add("е", "e");
                slova.Add("ж", "ž");
                slova.Add("з", "z");
                slova.Add("и", "i");
                slova.Add("ј", "j");
                slova.Add("к", "k");
                slova.Add("л", "l");
                slova.Add("м", "m");
                slova.Add("н", "n");
                slova.Add("о", "o");
                slova.Add("п", "p");
                slova.Add("р", "r");
                slova.Add("с", "s");
                slova.Add("т", "t");
                slova.Add("ћ", "ć");
                slova.Add("у", "u");
                slova.Add("ф", "f");
                slova.Add("х", "h");
                slova.Add("ц", "c");
                slova.Add("ч", "č");
                slova.Add("ш", "š");
            }
            // Method for cyrillic to latin
            private void button1_Click(object sender, EventArgs e)
            {
                string source = textBox1.Text;
                foreach (KeyValuePair<string, string> pair in slova)
                {
                    source = source.Replace(pair.Key, pair.Value);
                    // For upper case
                    source = source.Replace(pair.Key.ToUpper(), 
                                            pair.Value.ToUpper());                             
                }
                textBox2.Text = source;
            }
    
            // Method for latin to cyrillic
            private void button2_Click(object sender, EventArgs e)
            {
                string source = textBox2.Text;
                foreach (KeyValuePair<string, string> pair in slova)
                {
                    source = source.Replace(pair.Value, pair.Key);
                    // For upper case
                    source = source.Replace(pair.Value.ToUpper(),  
                                            pair.Key.ToUpper());
                }
                textBox1.Text = source;
            }
        }
    }
