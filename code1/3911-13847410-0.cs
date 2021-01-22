        public bool JustRedirected
        {
            get
            {
                if (Session[RosadaConst.JUSTREDIRECTED] == null)
                    return false;
                return (bool)Session[RosadaConst.JUSTREDIRECTED];
            }
            set
            {
                Session[RosadaConst.JUSTREDIRECTED] = value;
            }
        }
