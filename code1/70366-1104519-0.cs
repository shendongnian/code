     class MyString
        {
            private string _text;
            public string Text
            { get 
                 { 
                  return _text; 
                 }
                set 
                {
                    _text = value; 
                }
            }
    
        }
     private List<MyString> foo()
            {
                List<MyString> lst = new List<MyString>();
                MyString one = new MyString();
                MyString two = new MyString();
                one.Text = "Hello";
                two.Text = "Goodbye";
                lst.Add(one);
                lst.Add(two);
                return lst;
            }
    'In the executing form
            private void Form1_Load(object sender, EventArgs e)
            {
                dataGridView1.DataSource = foo();
                
            }
