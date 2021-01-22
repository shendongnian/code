        delegate void Del();
        [STAThread]
        static void Main()
        {
            Del d = new Del(TestMethod);
            var v = d.Method.GetCustomAttributes(typeof(ObsoleteAttribute), false);
            bool hasAttribute = v.Length > 0;
        }
        [Obsolete]
        public static void TestMethod()
        {
        }
