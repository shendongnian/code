    using System;
    using System.IO.Ports;
    using System.Text;
    using System.Windows.Forms;
    namespace ComPlay
    {
        public partial class MainForm : Form
        {
                private SerialPort m_port;
                private byte [] m_buffer = new byte[10];
                public MainForm()
                {
                        InitializeComponent();
                        m_list.Items.AddRange(SerialPort.GetPortNames());
                        m_list.SelectedIndex = 0;
                        m_port = new SerialPort(SerialPort.GetPortNames()[0],9600,Parity.None,8,StopBits.One);   
                        m_port.Handshake = Handshake.None;
                        m_port.RtsEnable = true;
                        m_port.DtrEnable = true;
                        m_port.DataReceived += DataReceivedEvent;
                        m_port.PinChanged += PinChangedEvent;
                }
                ~MainForm()
                {
                        if (m_port != null)
                                m_port.Close();
                }
                private void openClick(object sender, EventArgs e)
                {
                        if (m_port.IsOpen)
                                m_port.Close();
                        m_port.PortName = (string)m_list.SelectedItem;
                        try
                        {
                                m_port.Open();
                                m_buttonSend.Enabled = true;
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                                MessageBox.Show(ex.Message);
                        }
                }
                private void ButtonSendClick(object sender, EventArgs e)
                {
                        byte [] r_bytes = Encoding.ASCII.GetBytes(m_testBox.Text);
                        m_port.Write(r_bytes,0,r_bytes.Length);
                }
                private void DataReceivedEvent(object sender, SerialDataReceivedEventArgs args)
                {
                        Invoke(new EventHandler(DoUpdate));
                }
                private void DoUpdate(object s, EventArgs e)
                {
                        m_port.Read(m_buffer, 0, m_buffer.Length);
                        m_receivedText.Text += Encoding.ASCII.GetString(m_buffer); 
                }
                private void PinChangedEvent(object sender, SerialPinChangedEventArgs args)
                {
   
                }
        }
    }
