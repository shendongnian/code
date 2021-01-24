	private async void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
	{
		int bytes = COMport.BytesToRead;
		byte[] buffer = new byte[bytes];
		COMport.Read(buffer, 0, bytes);
		SetText(ASCIIEncoding.ASCII.GetString(buffer));
	
	
		if (Checked1)
		{
			await Task.Delay(5000);
			if (CheckBox_Port_CommandCheck_1.Checked)
				Check_ReceivedAnswer(ASCIIEncoding.ASCII.GetString(buffer), TextBox_ExpectedAnswer_1.Text, PictureBox_Reply_1);
			if (CheckBox_Port_CommandCheck_2.Checked)
				Check_ReceivedAnswer(ASCIIEncoding.ASCII.GetString(buffer), TextBox_ExpectedAnswer_2.Text, PictureBox_Reply_2);
		}
	}
