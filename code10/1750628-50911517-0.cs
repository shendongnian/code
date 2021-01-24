    var ser = new XmlSerializer(typeof(MyClass));
    using (var writer = XmlWriter.Create("Filename.XML", new XmlWriterSettings { Indent = true }))
    {
        writer.WriteStartElement("root");
        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        {
            MyClass abc = new MyClass(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
            ser.Serialize(writer, abc);
        }
        writer.WriteEndElement();
    }
