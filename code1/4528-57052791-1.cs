        public static object InvokeEx(this MethodInfo method, object obj, object[] parameters)
        {
            {
                return method.Invoke(obj, parameters);
            }
            catch (TargetInvocationException ex) when (ex.InnerException != null)
            {
                throw ex.InnerException.Capture();
            }
        }
