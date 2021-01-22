    static object InvokeMemberMethod(object currentObject, string methodName, int argCount, 
            ref object arg1, bool isOut1,
            ref object arg2, bool isOut2,
            ref object arg3, bool isOut3,
            ref object arg4, bool isOut4,
            ref object arg5, bool isOut5,
            ref object arg6, bool isOut6)
        {
            if (string.IsNullOrEmpty(methodName))
            {
                throw new ArgumentNullException("methodName");
            }
            if (currentObject == null)
            {
                throw new ArgumentNullException("currentObject");
            }
            Type[] argTypes = null;
            object[] args = null;
            if (argCount > 0)
            {
                argTypes = new Type[argCount];
                args = new object[argCount];
                argTypes[0] = arg1.GetType();
                if (isOut1)
                {
                    argTypes[0] = arg1.GetType().MakeByRefType();
                }
                args[0] = arg1;
                if (argCount == 2)
                {
                    argTypes[1] = arg2.GetType();
                    if (isOut2)
                    {
                        argTypes[1] = arg2.GetType().MakeByRefType();
                    }
                    args[1] = arg2;
                }
                
                if (argCount == 3)
                {
                    argTypes[2] = arg3.GetType();
                    if (isOut3)
                    {
                        argTypes[2] = arg3.GetType().MakeByRefType();
                    }
                    args[2] = arg3;
                }
                
                if (argCount == 4)
                {
                    argTypes[3] = arg4.GetType();
                    if (isOut4)
                    {
                        argTypes[3] = arg4.GetType().MakeByRefType();
                    }
                    args[3] = arg4;
                }
                
                if (argCount == 5)
                {
                    argTypes[4] = arg5.GetType();
                    if (isOut5)
                    {
                        argTypes[4] = arg5.GetType().MakeByRefType();
                    }
                    args[4] = arg5;
                }
                
                if (argCount == 6)
                {
                    argTypes[5] = arg6.GetType();
                    if (isOut6)
                    {
                        argTypes[5] = arg6.GetType().MakeByRefType();
                    }
                    args[5] = arg6;
                }
            }
            MethodInfo methodInfo = currentObject.GetType().GetMethod(methodName, argTypes);
            int retryCount = 0;
            object ret = null;
            bool success = false;
            do
            {
                try
                {
                    //if (methodInfo is MethodInfo)
                    {
                        Type targetType = currentObject.GetType();
                        ParameterInfo[] info = methodInfo.GetParameters();
                        ParameterModifier[] modifier = new ParameterModifier[] { new ParameterModifier(info.Length) };
                        int i = 0;
                        foreach (ParameterInfo paramInfo in info)
                        {
                            if (paramInfo.IsOut)
                            {
                                modifier[0][i] = true;
                            }
                            i++;
                        }
                        ret = targetType.InvokeMember(methodName, BindingFlags.InvokeMethod, null, currentObject, args,
                            modifier, null, null);
                        //ret = ((MethodInfo)methodInfo).Invoke(currentObject, args,);
                        success = true;
                    }
                    //else
                    {
                        // log error
                    }
                }
                catch (TimeoutException ex)
                {
                }
                catch (TargetInvocationException ex)
                {
                    throw;
                }
                retryCount++;
            } while (!success && retryCount <= 1);
            if (argCount > 0)
            {
                if (isOut1)
                {
                    arg1 = args[0];
                }
                if (argCount == 2)
                {
                    if (isOut2)
                    {
                        arg2 = args[1];
                    }
                }
                if (argCount == 3)
                {
                    if (isOut3)
                    {
                        arg3 = args[2];
                    }
                }
                if (argCount == 4)
                {
                    if (isOut4)
                    {
                        arg4 = args[3];
                    }
                }
                if (argCount == 5)
                {
                    if (isOut5)
                    {
                        arg5 = args[4];
                    }
                }
                if (argCount == 6)
                {
                    if (isOut6)
                    {
                        arg6 = args[5];
                    }
                }
            }
            return ret;
        }
        
        
        
        public int OutTest(int x, int y)
        {
            return x + y;
        }
        public int OutTest(int x, out int y)
        {
            y = x + 1;
            return x+2;
        }
        static void Main(string[] args)
        {
            object x = 1, y = 0, z = 0;
            Program p =  new Program();
            InvokeMemberMethod(p, "OutTest", 2, 
                ref x, false, 
                ref y, true, 
                ref z, false,
                ref z, false,
                ref z, false,
                ref z, false);
        }
