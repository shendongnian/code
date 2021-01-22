    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            Dictionary<string, string> slova = new Dictionary<string, string>();
    
            public Form1()
            {
                InitializeComponent();
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
                slova.Add("љ", "lj");
                slova.Add("м", "m");
                slova.Add("н", "n");
                slova.Add("њ", "nj");
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
                slova.Add("џ", "dž");
                slova.Add("ш", "š");
                
                slova.Add("А", "A");
                slova.Add("Б", "B");
                slova.Add("В", "V");
                slova.Add("Г", "G");
                slova.Add("Д", "D");
                slova.Add("Ђ", "Đ");
                slova.Add("Е", "E");
                slova.Add("Ж", "Ž");
                slova.Add("З", "Z");
                slova.Add("И", "I");
                slova.Add("Ј", "J");
                slova.Add("К", "K");
                slova.Add("Л", "L");
                slova.Add("Љ", "Lj");
                slova.Add("М", "M");
                slova.Add("Н", "N");
                slova.Add("Њ", "Nj");
                slova.Add("О", "O");
                slova.Add("П", "P");
                slova.Add("Р", "R");
                slova.Add("С", "S");
                slova.Add("Т", "T");
                slova.Add("Ћ", "Ć");
                slova.Add("У", "U");
                slova.Add("Ф", "F");
                slova.Add("Х", "H");
                slova.Add("Ц", "C");
                slova.Add("Ч", "Č");
                slova.Add("Џ", "Dž");
                slova.Add("Ш", "Š");
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string source = textBox1.Text;
                foreach (KeyValuePair<string, string> pair in slova)
                {
                    source = source.Replace(pair.Key, pair.Value);
                }
                textBox2.Text = source;
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                string source = textBox2.Text;
                foreach (KeyValuePair<string, string> pair in slova)
                {
                    source = source.Replace(pair.Value, pair.Key);
                }
                textBox1.Text = source;
            }
        }
    }
