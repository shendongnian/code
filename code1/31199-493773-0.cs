        public class ParentClass
        {
            public class NestedClass
            {
    
            }
        }
           private void button1_Click(object sender, EventArgs e)
            {
                Type t = typeof(ParentClass);
                Type t2 = t.GetNestedType("NestedClass");
                MessageBox.Show(t2.ToString());
            }
