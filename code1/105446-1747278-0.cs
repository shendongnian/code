    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            MyEnum z = MyEnum.Second;
            z++;
            z++;
            //see if a specific value is defined in the enum:
            bool isInTheEnum = !Enum.IsDefined(typeof(MyEnum), z);
            //get the max value from the enum:
            List<int> allValues = new List<int>(Enum.GetValues(typeof(MyEnum)).Cast<int>());
            int maxValue = allValues.Max();
        }
    }
    public enum MyEnum 
    {
        Zero = 0,
        First = 1,
        Second = 2,
        Third = 3
    }
