    public void SetControlText(Control control, string text)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action<Control,string>(SetControlText), new object[] { control, text });
        }
        else
        {
            control.Text = text;
        }
    }
    private void MyDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            //sp.PortName = "COM3";
            //sp.Open();
            SetControlText(Label1, sp.ReadLine());
        }
        catch (Exception exception)
        {
            SetControlText(RichTextBox1, exception.Message + "\n\n" + exception.Data);
        }
        finally
        {
            sp.Close();
        }
    }
