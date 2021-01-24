    private void button3_Click(object sender, EventArgs e)
    {
        IService1 patientSvc = null;
        EndpointAddress address = new EndpointAddress(baseAddress);
        ChannelFactory<IService1> factory = new ChannelFactory<IService1>(binding, address);
        patientSvc = factory.CreateChannel();
        Thread thread = new Thread(() => sendData(patientSvc));
        thread.Start();            
    }
    delegate void SetTextCallback(string text, bool isTxt2);
    private void SetText(string text, bool isTxt2)
    {
        if (isTxt2)
        {
            if (this.textBox2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                textBox2.Invoke(d, new object[] { text, isTxt2 });
            }
            else
            {
                textBox2.Text = text;
            }
        } else {
            if (this.textBox3.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                textBox2.Invoke(d, new object[] { text, isTxt2 });
            } else {
                this.textBox3.Text = text;
            }
        }
    }
    public void sendData(IService1 patientSvc)
    {
        Patient patient = patientSvc.GetPatient(Convert.ToInt32(textBox1.Text));
        if (patient != null)
        {
            SetText(patient.FirstName, true);
            SetText(patient.LastName, false);
        }
    }
