    private string GetMethodFullName
        {
            get
            {
                return this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            }
        }
