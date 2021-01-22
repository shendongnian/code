    public class DynamicArray<Type>
    {
        private Type[] internalArray;
        public DynamicArray()
        {
            internalArray = new Type[0];
        }
        public int Length
        {
            get
            {
                return internalArray.Length;
            }
            set
            {
                if (value >= 0)
                    Array.Resize<Type>(ref internalArray, value);
                else
                    throw new ArgumentOutOfRangeException
                    ("Length can not be less than zero!");
            }
        }
        public Type[] AsNormalArray
        {
            get
            {
                return internalArray;
            }
            set
            {
                internalArray = value;
            }
        }
        public Type this[int index]
        {
            get
            {
                if (index >= 0 && index < internalArray.Length)
                    return internalArray[index];
                else
                    throw new IndexOutOfRangeException
                    ("Index was outside the bounds of the array!");
            }
            set
            {
                //Get error handling out of the way first
                if (index < 0)
                    throw new IndexOutOfRangeException
                    ("Index must be greater than or equal to zero!");
                //I decided that being able to grow by any amount can eventually lead
                //to lots of bugs, think about it. Just set the length manually
                //by assigning to .Length :)
                if (index > internalArray.Length)
                    throw new IndexOutOfRangeException
                    ("Can not dynamically grow more than one element at a time! Set length manually.");
                //We are left with two possibilities. A. we are indexing an existing element or
                //B. we are indexing one element to high (same as length, big array no no)
                //so grow an element
                if (index < internalArray.Length)//Then we dont need to grow an element
                {
                    internalArray[index] = value;
                }
                else//Then grow one element, and add the value
                {
                    Array.Resize<Type>(ref internalArray, internalArray.Length + 1);
                    internalArray[index] = value;
                }
            }
        }
        public void Add(params Type[] values)
        {
            int start = internalArray.Length; //Start adding values at the end
            this.Length += values.Length; //Pre-set length (faster)
            foreach (Type val in values)
            {
                //this[start++] = val; Possibly slower
                internalArray[start++] = val;
            }
        }
        public int IndexOf(Type thisValue)
        {
            int i = 0;
            bool found = false;
            for(; i <= internalArray.Length; i++)
            {
                if(internalArray[i].Equals(thisValue))
                {
                    found = true;
                    break;
                }
            }
            if(found)
                return i;
            else
                throw new ArgumentException
                (thisValue+" does not exist!");
        }
        public bool Contains(Type thisValue)
        {
            bool found = false;
            foreach (Type val in internalArray)
            {
                if (val.Equals(thisValue))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
    }
    public class AssosiativeArray<ArrayT, KeyT>
    {
        //Easy peasy lemon squeezy
        private DynamicArray<ArrayT> values;
        private DynamicArray<KeyT> keys;
        public AssosiativeArray()
        {
            values = new DynamicArray<ArrayT>();
            keys = new DynamicArray<KeyT>();
        }
        public int Length
        {
            get
            {
                return values.Length;
            }
        }
        public ArrayT[] ValuesAsNormalArray
        {
            get
            {
                return values.AsNormalArray;
            }
        }
        public KeyT[] KeysAsNormalArray
        {
            get
            {
                return keys.AsNormalArray;
            }
        }
        public ArrayT this[KeyT index]
        {
            get
            {
                if (keys.Contains(index))
                {
                    return values[keys.IndexOf(index)];
                }
                else
                {
                    throw new ArgumentException
                    ("The key "+index+" does not exist!");
                }
            }
            set
            {
                keys[keys.Length++] = index;
                values[values.Length++] = value;
            }
        }
        public bool ContainsKey(KeyT key)
        {
            bool found = false;
            foreach (KeyT val in keys.AsNormalArray)
            {
                if (val.Equals(key))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
    }
}
