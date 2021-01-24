    public partial class Form1 : Form
    {
        private static int Rooms;              
        private Room[] room;
    
        public Form1()
        {
            InitializeComponent();
            Start();
        }
    
        private void Start()
        {
            string[] lines = File.ReadAllLines(@"C:Path\Test.txt");
            Rooms = lines.Length;
            room = new Room[Rooms]; 
            for (int i = 0; i < room.Length; i++)
            {
                if (i == 13)
                {
                    continue;
                }
                else
                {
                    this.room[i] = new Room(i);
                }
                listBox1.Items.Add(this.room[i].RoomNumber.ToString());
            }
        }
    }
