        public IsomeEntity Display<T>() where T : IsomeEntity
        {            
            IsomeEntity entity = factory.CreateObject(typeof(T).Name);
            return DoDisplay<T>(entity);
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
