    public DynamicallyOrderedList<T> : IList<T>
    {
       private readonly IList<T> m_Values;
       private readonly IList<int> m_Order;
       public DynamicallyOrderedList( IList<T> valueList, IList<int> ordering )
       {
           if( valueList == null || ordering == null ) 
               throw new ArgumentNullException();
           if( valueList.Count != ordering.Count )
               throw new InvalidArgumentException("Lists are not of same size.");
           // assumes ordering list has distinct values ranging from 0 to Count-1
           m_Values = valueList;
           m_Order  = ordering;           
       }
       // IList<T> Implementation
       
       // for simplicity, don't allow addition, removal or clearing of items
       // these could, however be implemented to add items to the end of the list 
       // and remove them by collapsing the ordering list. 
       // Left as an exercise for the reader :-)
       public void Add( T item ) { throw new NotSupportedException(); }
       public void Insert(int index, T item) { throw new NotSupportedException(); }
       public void Clear() { throw new NotSupportedException(); }
       public void Remove( T item ) { throw new NotSupportedException(); }
       public void RemoveAt( int index ) { throw new NotSupportedException(); }
       public T this[int index]
       {
           get 
           {
               if( index > m_Values.Count ) 
                   throw new ArgumentOutOfRangeException("index");
               return m_Values[m_Order[index]];
           }
           set
           {
               if( index > m_Values.Count ) 
                   throw new ArgumentOutOfRangeException("index");
               m_Values[m_Order[index]] = value;
           }
        }
       public int Count { get { return m_Values.Count; } }
       public bool Contains( T item ) { return m_Values.Contains( item ); }
       public bool IndexOf( T item ) { return m_Order[m_Values.IndexOf( item )]; }
       // Enumerator that returns items in the order defined by m_Order
       public IEnumerator<T> GetEnumerator()
       {
           // use generator syntax to simplify enumerator implementation
           foreach( var index in m_Order )
               yield return m_Values[index];
       }
       public void CopyTo( T[] array, int arrayIndex )
       {
            foreach( var item in this )
                array[arrayIndex++] = item;
       }
