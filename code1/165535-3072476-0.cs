    public partial class Form1 : Form
    {
        Dictionary<string, Label> files;
        public Form1()
        { 
            InitializeComponent();
            files = new Dictionary<string,Label>();
            files.Add("C:\\MonitorFiles\\BOT-PC-8is1.txt", PC8IS1);
            files.Add("C:\\MonitorFiles\\BOT-PC-8is2.txt", PC8IS2);
            files.Add("C:\\MonitorFiles\\BOT-PC-8is3.txt", PC8IS3);
         }
        public void otherFunc()
        {
            foreach (var item in files)
            {
                if (File.Exists(item.Key))
                    item.Value.BackColor = Color.Green;
            }
        }
    }
