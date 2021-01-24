        public static void Main()
        {
            try
            {           
                Subfunction();
                Thirdfunction();
            }
            catch(Exception ex)
            {
            }
        }    
        public static void Subfunction()
        {
            try
            {
    			throw new AccessViolationException();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
