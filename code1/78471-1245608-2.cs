    private delegate IsomeEntity DisplayDelegate<T>(IsomeEntity display);
        
        public IsomeEntity DisplayMethod<T>() where T : IsomeEntity
        {
            DisplayDelegate<T> _del = new DisplayDelegate<T>(DoDisplay<T>);
            IsomeEntity entity = factory.CreateObject(typeof(T).Name);
            return _del(entity);
        }   
        public IsomeEntity DoDisplay<T>(IsomeEntity entity)
        {
            try
            {
                Display<T> o = new Display<T>();
                Entity<T> response = o.Display(entity);
                return response;
            }
            catch (Exception ex)
            {
                if (someExceptionHandler.HandleException(ex, this, out newEx))
                    throw newEx;
            }
        }
