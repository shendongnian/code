        public void SetProperties(params object[] args)
        {
            for (int i = 0; i < args.Count(); i += 2)
            {
                PropertyInfo myProp = this.GetType().GetProperty(args[i].ToString());
                myProp.SetValue(this, args[i + 1]);
            }
        }
