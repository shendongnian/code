        bool mRepeating;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == (Keys.Control | Keys.F) && !mRepeating) {
                mRepeating = true;
                Console.WriteLine("What the Ctrl+F?");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public override bool PreProcessMessage(ref Message msg) {
            if (msg.Msg == 0x101) mRepeating = false;
            return base.PreProcessMessage(ref msg);
        }
