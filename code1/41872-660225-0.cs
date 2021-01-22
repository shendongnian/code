    // Stream s...
    byte[] buffer = new buffet[bufferSize];
    s.BeginRead(b, 0, buffer.Length,
        delegate
            {
                if (textBox1.InvokeRequired)
                {
                    textBox1.Invoke(
                        new MethodInvoker(
                            delegate 
                            { 
                                textBox1.Text = Encoding.Unicode.GetString(b); 
                            }));
                }
                else
                {
                    textBox1.Text = Encoding.Unicode.GetString(b);
                }
             }, null);
