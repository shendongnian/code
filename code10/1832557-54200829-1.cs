    string IDataErrorInfo.Error
        {
            get
            {
                StringBuilder error = new StringBuilder();
                if (!int.TryParse(Cycle.ToString(), out int i))
                {
                    error.Append("Cycle should be an integer value.");
                }
                return error.ToString();
            }
        }
