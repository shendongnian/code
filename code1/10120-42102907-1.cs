    private void Execution()
    {
        btnCompare.Invoke((MethodInvoker)delegate { pictureBox1.Visible = true; });
        Application.DoEvents();
        // Your main code comes here . . .
        btnCompare.Invoke((MethodInvoker)delegate { pictureBox1.Visible = false; });
    }
