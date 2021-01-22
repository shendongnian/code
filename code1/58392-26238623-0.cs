        public enum Colors
        {
            Red = 10,
            Blue = 20,
            Green = 30,
            Yellow = 40,
        }
    
    comboBox1.DataSource = Enum.GetValues(typeof(Colors));
