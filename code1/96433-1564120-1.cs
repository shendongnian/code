        /// <summary>
        /// This is a thread safe operation.
        /// </summary>
        /// <param name="text"></param>
        public void SetTextBoxText(string text)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { SetText(text); });
                return;
            }
            // To get to this line the proper thread was used (by invoking)
            myTextBoxt.Text += text;
        }
        /// <summary>
        /// This is an alternative way. It uses a Lambda and BeginInvoke
        /// which does not block the thread.
        /// </summary>
        /// <param name="text"></param>
        public void SetTextBoxText(string text)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)(() => { SetText(text); }));
                return;
            }
            // To get to this line the proper thread was used (by invoking)
            myTextBox.Text += text;
        }
