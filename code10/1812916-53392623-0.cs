       private void button2_Click(object sender, EventArgs e)
        {
            var msg = Encoding.ASCII.GetBytes(m_textbox.Text).ToList();
            msg.Insert(0, 0x02); // STX at the start
            msg.Add(0x03); // ETX at the end
            m_port.Write(msg.ToArray(), 0, msg.Length);
        }
