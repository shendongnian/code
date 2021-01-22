        private Queue<string> messages = new Queue<string>();
        /// <summary>
        /// Add Message To The Queue
        /// </summary>
        /// <param name="text"></param>
        public void NewMessage(string text)
        {
            lock (messages)
            {
                messages.Enqueue(text);
            }
        }
        private void tmr_Tick(object sender, EventArgs e)
        {
            if (messages.Count == 0) return;
            lock (messages)
            {
                this.textBox.Text += Environment.NewLine + messages;
            }
        }
