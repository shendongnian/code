        public int ExecuteCommandEx(string sCommand, params object[] parameters)
        {
            object[] newParams = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == null)
                    newParams[i] = "NULL";
                else if (parameters[i] is System.Guid || parameters[i] is System.String || parameters[i] is System.DateTime)
                    newParams[i] = string.Format("'{0}'", parameters[i]);
                else if (parameters[i] is System.Int32 || parameters[i] is System.Int16)
                    newParams[i] = string.Format("{0}", parameters[i]);
                else
                {
                    string sNotSupportedMsg = string.Format("Type of param {0} not currently supported.", parameters[i].GetType());
                    System.Diagnostics.Debug.Assert(false, sNotSupportedMsg);
                }
            }
            return ExecuteCommand(string.Format(sCommand, newParams));
        }
