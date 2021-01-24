    CreateRoomWindow menuWindow = new CreateRoomWindow(client);
    menuWindow.ShowDialog();
    //Doesn't call close any more
    public partial class CreateRoomWindow : Window
    {
        TcpClient client;
        const int createRoomMessage = 206;
        public CreateRoomWindow(TcpClient loggedClient)
        {
            InitializeComponent();
            client = loggedClient;
        }
        private void Form1_FormClosed(Object sender, FormClosedEventArgs e)
        {
            client.Close();  //Closes after we're done with the form
        }
    }
