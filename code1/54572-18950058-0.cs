     public class JSList<T> : List<T>
    {
        public JSList() : base() {}
        /// <summary>
        /// this the add item to the start of the list
        /// </summary>
        /// <param name="v"></param>
        public void Shift(T v)
        {
            this.Insert(0, v);
        }
        /// <summary>
        /// remove item at the start of the list
        /// </summary>
        /// <returns></returns>
        public T Unshift()
        {
            var toreturn = default(T);
            if (this.Count > 0)
            {
                toreturn = this[0];
                this.RemoveAt(0);
            }
            return toreturn;
        }
        /// <summary>
        /// Adds object to end of the list
        /// </summary>
        /// <param name="v"></param>
        public void Push(T v)
        {
            this.Add(v);
        }
        /// <summary>
        /// removes an item at the end of the list
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            var toreturn = default(T);
            if (this.Count > 0)
            {
                toreturn = this[this.Count - 1];
                this.RemoveAt(this.Count - 1);
            }
            return toreturn;
        }
        public T Peek()
        {
            return this[this.Count - 1];
        }
    }
