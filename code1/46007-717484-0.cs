        private void SetMemo(string txt)
        {
            Memo.Text = txt;
        }
        private delegate void MemoSetter(string txt);
        public void ThreadSafeSet(string txt)
        {
            Invoke(new MemoSetter(SetMemo), txt);
        }
 
