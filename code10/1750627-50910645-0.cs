    private class MyClassList
    {
       IEnumerable<MyClass> Root{  get;  set;}
    }
    private void expXML_Click(object sender, EventArgs e)
    {
        var myClassList = new MyClassList();
        myClassList.Root = new List<MyClass>();
        XmlSerializer ser = new XmlSerializer(typeof(MyClass));
        TextWriter writer = new StreamWriter("Filename.XML");
        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        {
            MyClass abc = new MyClass(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
            myClassList.Root.Add(abc);
        }
        ser.Serialize(writer, myClassList);
        writer.Close();
    }
