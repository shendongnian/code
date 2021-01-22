        public bool IsPathFileNameGood(string fname)
        {
            bool rc = Constants.Fail;
            try
            {
                this._stream = new StreamWriter(fname, true);
                rc = Constants.Pass;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Problem opening file");
                rc = Constants.Fail;
            }
            return rc;
        }
