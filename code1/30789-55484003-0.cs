        public CustomException: ( Exception exception ) : base(exception.Message)
        {             
            Data.Add("StackTrace",exception.StackTrace);
        }      
    }
    
