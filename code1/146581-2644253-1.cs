        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool processed = false;
            switch (keyData)
            {
                case Keys.Alt | Keys.D1:
                    if (this._condition1)
                        processed = true;
                    break;
                case Keys.Control | Keys.U:
                    if (this._condition2)
                        processed = true;
                    break;
            }
            if (!processed)
                processed = base.ProcessCmdKey(ref msg, keyData);
            return processed;
        }
