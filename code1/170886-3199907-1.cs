    class A
    {
        private DTOa _dto = new DTOa();
        protected virtual DTOa GetDTO()
        {
            return _dto;
        }
        public string FirstName
        {
            get { return GetDTO().FirstName; }
            set { GetDTO().FirstName = value; }
        }
        ...
    }
    class B : A
    {
        private DTOb _dto = new DTOb();
        protected virtual DTOa GetDTO()
        {
            return _dto;
        }
        public string Email
        {
            get { return GetDTO().Email; }
            set { GetDTO().Email = value; }
        }
        ...
    }
