    public class Hashtable2D
    {
        /// <summary>
        /// This is a hashtable of hashtables
        /// The X dim is the root key, and the y is the internal hashes key
        /// </summary>
        /// 
        private Hashtable root = new Hashtable();
        public bool overwriteDuplicates = false;
        public bool alertOnDuplicates = true;
        public void Add(object key_x, object key_y, object toStore)
        {
            if(root[key_x]!=null)//If key_x has already been entered 
            {
                Hashtable tempHT = (Hashtable)root[key_x];//IF the hash table does not exist then focus will skip to the catch statement
                if (tempHT[key_y] == null)  tempHT.Add(key_y, toStore);
                else handleDuplicate(tempHT, key_y, toStore);
            }else{//Making a new hashtable 
                Hashtable tempHT = new Hashtable();
                tempHT.Add(key_y, toStore);
                root.Add(key_x, tempHT);
            }
        }
        public void Remove(object key_x, object key_y)
        {
            try{
                ((Hashtable)root[key_x]).Remove(key_y);
            }catch(Exception e){
                MessageBox.Show("That item does not exist");
            }
        }
        
        public void handleDuplicate (Hashtable tempHT, object key_y, object toStore)
        {
            if (alertOnDuplicates) MessageBox.Show("This Item already Exists in the collection");
            if (overwriteDuplicates)
            {
                tempHT.Remove(key_y);
                tempHT.Add(key_y,toStore);
            }
        }
        public object getItem(object key_x, object key_y)
        {
            Hashtable tempHT = (Hashtable)root[key_x];
            return tempHT[key_y];
        }
        public ClassEnumerator GetEnumerator()
        {
            return new ClassEnumerator(root);
        }
        public class ClassEnumerator : IEnumerator
        {
            private Hashtable ht;
            private IEnumerator iEnumRoot;
            private Hashtable innerHt;
            private IEnumerator iEnumInner;
            public ClassEnumerator(Hashtable _ht)
            {
                ht = _ht;
                iEnumRoot = ht.GetEnumerator();
                iEnumRoot.MoveNext();//THIS ASSUMES THAT THERE IS AT LEAST ONE ITEM
                innerHt = (Hashtable)((DictionaryEntry)iEnumRoot.Current).Value;
                iEnumInner = innerHt.GetEnumerator();
            }
            #region IEnumerator Members
            public void Reset()
            {
                iEnumRoot = ht.GetEnumerator();
            }
            public object Current
            {
                get
                {
                    return iEnumInner.Current; 
                }
            }
            public bool MoveNext()
            {
                if(!iEnumInner.MoveNext())
                {
                    if (!iEnumRoot.MoveNext()) return false;
                    innerHt = (Hashtable)((DictionaryEntry)iEnumRoot.Current).Value;
                    iEnumInner = innerHt.GetEnumerator();
                    iEnumInner.MoveNext();
                }
                return true;
            }
            #endregion
        }
        
    }
}
