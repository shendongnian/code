        public object[,] RemoveZeros(object range)
        {
            return this.RemoveZeros(range.ToObjectArray());
        }
        [ComVisible(false)]
        [UdfMethod(IsVolatile = false)]
        public object[,] RemoveZeros(Object[,] range)
        {...}
