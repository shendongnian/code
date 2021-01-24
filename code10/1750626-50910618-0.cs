    private void expXML_Click(object sender, EventArgs e)
    {
        List<MyClass> newList = new List<MyClass>();
        XmlSerializer ser = new XmlSerializer(typeof(List<MyClass>));
        TextWriter writer = new StreamWriter("Filename.XML");
        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        {
            MyClass abc = new MyClass(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
            newList.add(abc);            
        }
        ser.Serialize(writer, newList);
        writer.Close();
    }
