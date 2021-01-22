        private void button2_Click(object sender, EventArgs e)
        {
            //performance test
            testClass t = new testClass();
            System.Diagnostics.Stopwatch sw1 = new System.Diagnostics.Stopwatch();
            sw1.Start();
            for (int i = 0; i < int.MaxValue; i++)
            {
                string result = t.myString1;
            }
            sw1.Stop();
    
            System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();
            sw2.Start();
            for (int i = 0; i < int.MaxValue; i++)
            {
                string result = t.myString2;
            }
            sw2.Stop();
    
            System.Diagnostics.Stopwatch sw3 = new System.Diagnostics.Stopwatch();
            sw3.Start();
            for (int i = 0; i < int.MaxValue; i++)
            {
                string result = t.myString3();
            }
            sw3.Stop();
            MessageBox.Show(string.Format("Direct: {0}, Getter: {1}, Method: {2}"
                , sw1.ElapsedMilliseconds.ToString()
                , sw2.ElapsedMilliseconds.ToString()
                , sw3.ElapsedMilliseconds.ToString()));
        }
    
    
    class testClass 
    { 
        public string myString1 = "hello";
        public string myString2 { get { return "hello"; } }
        public string myString3() { return "hello"; } 
    }
