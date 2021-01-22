        private void SetVisibleByDelegate()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) SetVisibleByDelegate);
            }
            else
            {
                Visible = true;
            }
        }
