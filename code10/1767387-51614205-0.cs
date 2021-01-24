    public class Product {
    
        public string Name { get; set; }
    
        public DateTime Expiry { get; set; }
    
        public string[ ] Sizes { get; set; }
    
      }
    
    
      public class DictionaryWithJsonSerailization<TKey, TValue> : IDictionary<TKey, TValue>, INotifyPropertyChanged {
    
        #region Events
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        #endregion
    
        #region Private fields
    
        int _count;
    
        List<KeyValuePair<TKey, TValue>> _interalList;
    
        #endregion
    
        #region Constructor
    
        public DictionaryWithJsonSerailization( ) {
          _count = 0;
          _interalList = new List<KeyValuePair<TKey, TValue>>( );
        }
    
        #endregion
    
        #region implementation of IDictionary<TKey, TValue> interface
    
        private bool TryGetIndexOfKey( Object key, out Int32 index ) {
          for( index = 0; index < _count; index++ ) {
    
            if( _interalList[ index ].Key.Equals( key ) )
              return true;
          }
    
    
          return false;
        }
    
        public TValue this[ TKey key ] {
          get {
            int index;
            if( TryGetIndexOfKey( key, out index ) ) {
              return ( TValue )_interalList[ index ].Value;
            }
            else {
              return default( TValue );
            }
          }
    
          set {
            int index;
            if( TryGetIndexOfKey( key, out index ) ) {
    
              var temp = _interalList[ index ].Value;
              temp = value;
            }
            else {
              Add( key, value );
            }
          }
        }
    
        public ICollection<TKey> Keys {
          get {
            return _interalList.Select( x => ( TKey )x.Key ).ToList( );
          }
        }
    
        public ICollection<TValue> Values {
          get {
            return _interalList.Select( x => ( TValue )x.Value ).ToList( );
          }
        }
    
        public int Count {
          get {
            return _count;
          }
        }
    
        public bool IsReadOnly {
          get {
            return false;
          }
        }
    
        public void Add( TKey key, TValue value ) {
          _interalList.Add( new KeyValuePair<TKey, TValue>( key, value ) );
          _count = _count + 1;
          NotifyObserversOfChange( );
        }
    
        public void Add( KeyValuePair<TKey, TValue> item ) {
          _interalList.Add( item );
          _count = _count + 1;
          NotifyObserversOfChange( );
        }
    
        public void Clear( ) {
          _count = 0;
          _interalList = new List<KeyValuePair<TKey, TValue>>( );
          NotifyObserversOfChange( );
        }
    
        public bool Contains( KeyValuePair<TKey, TValue> item ) {
          int index_;
          return TryGetIndexOfKey( item.Key, out index_ );
        }
    
        public bool ContainsKey( TKey key ) {
          int index_;
          return TryGetIndexOfKey( key, out index_ );
        }
    
        public void CopyTo( KeyValuePair<TKey, TValue>[ ] array, int arrayIndex ) {
          throw new NotImplementedException( );
        }
    
        public bool Remove( TKey key ) {
          int index_;
          var temp = TryGetIndexOfKey( key, out index_ );
    
          if( temp ) {
            _interalList.RemoveAt( index_ );
            _count = _count - 1;
            NotifyObserversOfChange( );
            return true;
          }
          else {
            return false;
          }
    
        }
    
        public bool Remove( KeyValuePair<TKey, TValue> item ) {
          int index_;
          var temp = TryGetIndexOfKey( item.Key, out index_ );
    
          if( temp ) {
            _interalList.RemoveAt( index_ );
            _count = _count - 1;
            NotifyObserversOfChange( );
            return true;
          }
          else {
            return false;
          }
        }
    
        public bool TryGetValue( TKey key, out TValue value ) {
          int index_;
          var temp = TryGetIndexOfKey( key, out index_ );
    
          if( temp ) {
            value = ( TValue )_interalList[ index_ ].Value;
            return true;
          }
          else {
            value = default( TValue );
            return false;
          }
        }
    
        IEnumerator IEnumerable.GetEnumerator( ) {
          return ( ( IDictionary<TKey, TValue> )this ).GetEnumerator( );
        }
    
        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator( ) {
          return _interalList.GetEnumerator( );
        }
    
        #endregion
    
        #region Private methods
    
        private void NotifyObserversOfChange( ) {
          var propertyHandler = PropertyChanged;
          if( propertyHandler != null ) {
            if( propertyHandler != null ) {
              propertyHandler( this, new PropertyChangedEventArgs( "Count" ) );
              propertyHandler( this, new PropertyChangedEventArgs( "Keys" ) );
              propertyHandler( this, new PropertyChangedEventArgs( "Values" ) );
            }
          }
        }
    
        #endregion
    
      }
    
      public class Wrapper {
    
        DictionaryWithJsonSerailization<string, Product> dictA_;
    
        public Wrapper( ) {
          dictA_ = new DictionaryWithJsonSerailization<string, Product>( );
          dictA_.PropertyChanged += ( sener, i ) => SerializeToJson( );
    
    
        }
    
        public DictionaryWithJsonSerailization<string, Product> DictA {
          get {
            return dictA_;
          }
          set {
            dictA_ = value;
          }
        }
    
        public void SerializeToJson( ) {
          string path = @"...\JsonTest.json";
          string json = JsonConvert.SerializeObject( this );
          JsonSerializer serializer = new JsonSerializer( );
    
          using( StreamWriter sw = new StreamWriter( path ) ) {
            using( JsonWriter writer = new JsonTextWriter( sw ) ) {
              serializer.Serialize( writer, this );
            }
          }
        }
    
      }
    static void Main( string[ ] args ) {
    
    
          Product product = new Product( );
          product.Name = "Apple";
          product.Expiry = new DateTime( 2008, 12, 28 );
          product.Sizes = new string[ ] { "Small" };          
        
          var temp = new Wrapper( );    
          temp.DictA.Add( "test", product );
          Thread.Sleep( 1000 * 15 );
          temp.DictA.Add( "test2", product );
          Thread.Sleep( 1000 * 15 );
          temp.DictA.Add( "test3", product );
    }
