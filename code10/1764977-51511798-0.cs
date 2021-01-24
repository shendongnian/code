     `  private void Serial_btn_1_Click(object sender, EventArgs e)
        {
               Test_Timer.Interval = 15;
                Test_Timer.Tick += new System.EventHandler(TimerEventProcessor);
                Test_Timer.Start();
        }
    private void TimerEventProcessor(object sender, EventArgs e)
        {
            try
            {
                bytes1 = serialPort1.BytesToRead;
                bytes1 = serialPort2.BytesToRead;
                bytes1 = serialPort3.BytesToRead;
                bytes1 = serialPort4.BytesToRead;
                linef_1 = new byte[bytes1];
                linef_2 = new byte[bytes2];
                linef_3 = new byte[bytes3];
                linef_4 = new byte[bytes4];
            }
            catch { }
            try
            {
                serialPort1.Read(linef_1, 0, bytes1);
                serialPort2.Read(linef_2, 0, bytes2);
                serialPort3.Read(linef_3, 0, bytes3);
                serialPort4.Read(linef_4, 0, bytes4);
            }
            catch
            {
                //  MessageBox.Show("Read_data no");
            }
            Invoke((MethodInvoker)delegate
            {
                richTextBox1.AppendText(ByteToHex(linef_1));
                richTextBox2.AppendText(ByteToHex(linef_2));
                richTextBox3.AppendText(ByteToHex(linef_3));
                richTextBox4.AppendText(ByteToHex(linef_4));
            });
        }
