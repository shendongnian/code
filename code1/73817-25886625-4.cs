        private void SetVisibleByNewAction()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(SetVisibleByNewAction));
            }
            else
            {
                Visible = true;
            }
        }
