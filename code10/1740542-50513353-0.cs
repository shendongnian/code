    ...
    public Form1()
    {
      InitializeComponent();
      getAvailablePorts();
      // Subscribe to the DataReceived event.  Our function Serial_DataReceived
      // will be called whenever there's data available on the serial port.
      serial.DataReceived += Serial_DataReceived;
    }
    // Appends the given text to the given textbox in a way that is cross-thread
    // safe.  This can be called by any thread, not just the UI thread.
    private void AppendText(TextBox textBox, string text)
    {
      // If Invoke is required, i.e. we're not running on the UI thread, then
      // we need to invoke it so that this function gets run again but on the UI
      // thread.
      if (textBox.InvokeRequired)
      {
        textBox.BeginInvoke(new Action(() => AppendText(textBox, text)));
      }
      // We're on the UI thread, we can append the new text.
      else
      {
        textBox.Text += text;
      }
    }
    // Gets called whenever we receive data on the serial port.
    private void Serial_DataReceived(object sender,
      SerialDataReceivedEventArgs e)
    {
      string serialData = serial.ReadExisting();
      AppendText(textBox5, serialData);
    }
