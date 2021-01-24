    public partial class YourFirstForm : Form
    {
        string someString = "Some random string";
        public YourFirstForm()
        {
            InitializeComponents();
        }
        public MyNewObject GetSomeData()
        {
            MyNewObject mno = new MyNewObject();
            mno.Name = "Random name";
            mno.Id = 1;
            mno.Speed = 200;
            return mno;
        }
    }
