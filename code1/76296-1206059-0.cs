        string GetPropertyName()
        {
            StackTrace callStackTrace = new StackTrace();
            StackFrame propertyFrame = callStackTrace.GetFrame(1); // 1: below GetPropertyName frame
            string properyAccessorName = propertyFrame.GetMethod().Name;
            return properyAccessorName.Replace("get_","").Replace("set_","");
        }
