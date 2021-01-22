    using System.Threading.Tasks;
    using System.Threading;
    namespace TESTE
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Action<string> DelegateTeste_ModifyText = THREAD_MOD;
                Invoke(DelegateTeste_ModifyText, "MODIFY BY THREAD");
            }
            private void THREAD_MOD(string teste)
            {
                textBox1.Text = teste;
            }
        }
    }
