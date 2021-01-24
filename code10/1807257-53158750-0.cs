        if (checkBox1.Checked)
        {
            string finalName = @"C:\testing\" + selectDept + selectWorker + @"\IP"
				+ dateTime.Year + dateTime.Month + dateTime.Day + ".pdf";
            textBox2.Text = finalName;
            File.Copy(myFile, finalName, true);
        }
		if (checkBox2.Checked)
        {
            string finalName = @"C:\testing\" + selectDept + selectWorker + @"\PR"
              + dateTime.Year + dateTime.Month + dateTime.Day + ".pdf";
            textBox2.Text = finalName;
            File.Copy(myFile, finalName, true);
        }
