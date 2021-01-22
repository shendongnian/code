            string sArgs = string.Empty;
            string delim = string.Empty;
            bool isNumeric = false;
            int iArg = 0;
            if (methodArgs != null && methodArgs.Length > 0)
            {
                foreach (string arg in methodArgs)
                {
                    isNumeric = int.TryParse(arg, out iArg);
                    sArgs += delim + ((isNumeric) ? arg : "'" + arg + "'");
                    delim = ",";
                }
            }
            ScriptManager manager = (ScriptManager)Master.FindControl("ScriptManager1");
            if (manager.IsInAsyncPostBack)
            {
                manager.RegisterDataItem(Master.FindControl("JSBridge"), methodName + "(" + sArgs + ")");
            }
        }
