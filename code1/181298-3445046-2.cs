        protected string[,] MyArray
        {
            get
            {
                //Insert your array here
                return new string[,]{{"1", "1"}, {"2", "2"}};
            }
        }
        protected int ArrayDimensionLength
        {
            get
            {
                return (int)Math.Sqrt(MyArray.Length);
            }
        }
