       public virtual void Push(object obj)
        {
            if (this._size == this._array.Length)
            {
                object[] destinationArray = new object[2 * this._array.Length];
                Array.Copy(this._array, 0, destinationArray, 0, this._size);
                this._array = destinationArray;
            }
            this._array[this._size++] = obj;
            this._version++;
        }
    
    
     public virtual object Pop()
        {
            if (this._size == 0)
            {
                throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EmptyStack"));
            }
            this._version++;
            object obj2 = this._array[--this._size];
            this._array[this._size] = null;
            return obj2;
        }
