    public Status status = Status.Enable;
        public List<string> Statusstring {
            get
            {
                return System.Enum.GetNames(typeof(Status)).ToList();
            }
        }
