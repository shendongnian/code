    public int a;
        
    public void Execute(object parameter)
        {
            var id_movie = (int)parameter;
            var rowIndex = id_movie - 1;
            a = (_vModel.Library2[rowIndex]["id_movie"]);
        }
        private static int b = a;
        public static int Name
        {
            get { return b; }
            set { b = value; }
    
        }
