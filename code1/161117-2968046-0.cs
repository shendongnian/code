        public string GetFoo1(bool bar)
        {
            if (bar)
                return "";
            else
                NewCustomException();
        }
        public string GetFoo2(bool bar)
        {
            if (bar)
                return "";
            else
                throw new CustomException("Exception message");
        }
