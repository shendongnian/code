    public class aa
    {
        private string myVar;
        public string value
        {
            get { return myVar; }
            set { myVar = value; }
        }	
    }
    private void button1_Click(object sender, EventArgs e)
    {
        aa a1 = new aa();
        System.Reflection.PropertyInfo pt = typeof(aa).GetProperty("value");
        pt.SetValue(a1, "hi",null);
        this.Text = a1.value;
    }
