        private void button2_Click(object sender, EventArgs e)
        {
            var p = new { a = 10, b = 20 };
            TestMethod(p);
        }
        private void TestMethod(object p)
        {
            Type t = p.GetType();
            foreach (PropertyInfo pi in t.GetProperties())
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} = {1}", pi.Name, 
                    t.InvokeMember(pi.Name, BindingFlags.GetProperty, null, p, null)));
            }
        }
