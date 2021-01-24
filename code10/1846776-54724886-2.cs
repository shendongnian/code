        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                // do some "work" in our new thread
                for(int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(1000); // the "work"
                    // when you need to UPDATE THE UI, now is the time for Invoke()
                    // note that only the part that is updating the UI is within this block
                    // the rest of the code/loop is still running in the new thread
                    URLLMemoRichTxt.Invoke((MethodInvoker)delegate ()
                    {
                        URLLMemoRichTxt.AppendText("Line " + i.ToString() + "\r\n");
                    });
                    // ... possibly more work in the new thread ...
                }
            }).Start();
        }
