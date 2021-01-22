    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            myGen myStringEnumerator = new myGen(myGen.wanted.nextNum);
            myGen evenNumberGenerator = new myGen(myGen.wanted.EvenNum);
            for (int i = 0; i <= 5; i++)
            {
                MessageBox.Show(string.Format("Identifier{0}.xml", myStringEnumerator.GetNext().ToString("00")));
            }
            for (int i = 0; i <= 5; i++)
            {
                MessageBox.Show(evenNumberGenerator.GetNext().ToString());
            }
        }
    }
    public class myGen
    {
        private int num = 0;
        public enum wanted
        {
            nextNum,
            EvenNum,
            OddNum
        }
        private wanted _wanted;
        public myGen(wanted wanted)
        {
            _wanted = wanted;
        }
        public int GetNext()
        {
            num++;
            if (_wanted == wanted.EvenNum)
            {
                if (num % 2 == 1)
                {
                    num++;
                }
            }
            else if (_wanted == wanted.OddNum)
            {
                if (num % 2 == 0)
                {
                    num++;
                }
            }
            return num;
        }
    }
