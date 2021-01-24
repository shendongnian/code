    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO.Ports;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Data;
    using System.Drawing;
    namespace cube
    {
        /// <summary>
        /// Interaktionslogik für MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                getAvailablePorts();
                serial.DataReceived += Serial_DataReceived;
            }
        public bool button3clicked = false;
        public bool button4clicked = false;
        public bool button5clicked = false;
        SerialPort serial = new SerialPort();
        void getAvailablePorts()
        {            
            List<string> Itemlist = new List<string>();
            String[] ports = SerialPort.GetPortNames();
            Itemlist.AddRange(ports);
            comboBox1.ItemsSource = Itemlist;            
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Please Select Port Settings");
                }
                else
                {
                    serial.PortName = comboBox1.Text;
                    serial.BaudRate = Convert.ToInt32(textBox6.Text); 
                    serial.Parity = Parity.None;
                    serial.StopBits = StopBits.One;
                    serial.DataBits = 8;
                    serial.Handshake = Handshake.None;
                    serial.Open();
                    MessageBox.Show("connected!");
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Unauthorised Access");
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            MessageBox.Show("connection closed!");
            serial.Close();
            textBox1.Text = "test";
        }
        private void AppendText(string[] text)
        {
            try
            {             
                    textBox1.Text = text[0];
                    textBox2.Text = text[1];
                    textBox3.Text = text[2];
                    textBox4.Text = text[3];                
            }
            catch (Exception) { }
        }
        private void Safe_Position1(TextBox tBr1, TextBox tBi1, TextBox tBj1, TextBox tBk1, string[] text)
        {
            if (button3clicked == true)
            {               
                    tBr1.Text = text[0];
                    tBi1.Text = text[1];
                    tBj1.Text = text[2];
                    tBk1.Text = text[3];
                    button3clicked = false;
            }
        }
        private void Safe_Position2(TextBox tBr2, TextBox tBi2, TextBox tBj2, TextBox tBk2, string[] text)
        {
            if (button4clicked == true)
            {                           
                    tBr2.Text = text[0];
                    tBi2.Text = text[1];
                    tBj2.Text = text[2];
                    tBk2.Text = text[3];
                    button4clicked = false;               
            }
        }
        private void Safe_Position3(TextBox tBr3, TextBox tBi3, TextBox tBj3, TextBox tBk3, string[] text)
        {
            if (button5clicked == true)
            {              
                    tBr3.Text = text[0];
                    tBi3.Text = text[1];
                    tBj3.Text = text[2];
                    tBk3.Text = text[3];
                    button5clicked = false;             
            }
        }
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string serialData = serial.ReadLine();
            String[] text = serialData.Split(new char[] { ' ' });
            AppendText(text);
            Safe_Position1(textBox5, textBox7, textBox8, textBox9, text);
            Safe_Position2(textBox10, textBox11, textBox12, textBox13, text);
            Safe_Position3(textBox14, textBox15, textBox16, textBox17, text);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3clicked = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button4clicked = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            button5clicked = true;
        }
    }
}
