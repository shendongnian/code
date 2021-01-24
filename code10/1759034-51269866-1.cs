    class DatabaseCar : Data
    {
        public override void set(string color, string engine, string name)
        {
            this.color = color;
            this.engine = engine;
            this.name = name;
        }
        public DatabaseCar(string color, string engine, string name)
        {
            set(color, engine, name);
        }
        public override string ToString()
        {
            string result = string.Empty;
            result += string.Format("Name : {0}", name) + Environment.NewLine;
            result += string.Format("Color : {0}", color) + Environment.NewLine;
            result += Environment.NewLine;
            return result;
        }
    }
