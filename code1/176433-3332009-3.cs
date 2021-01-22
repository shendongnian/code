    public class Choices
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    class Program
    {
        private void SetValues(Choices choices)
        {
            var list = new List<Choices>(choices);
            comboBox1.DataSource = list;
            comboBox1.ValueMember = "Price";
            comboBox1.DisplayMember = "Name";
        }
    }
