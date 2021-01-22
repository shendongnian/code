        private void ppTrace(string tv)
        {
            if (_Txb1.InvokeRequired)
            {
                _Txb1.Invoke((Action<string>)ppTrace, tv);
            }
            else
            {
                _Txb1.AppendText(tv + Environment.NewLine);
            }
        }
