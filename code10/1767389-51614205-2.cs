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
    
    
        Dictionary<TKey, TValue> _interalDictionary;
    
        #endregion
    
        #region Constructor
    
        public DictionaryWithJsonSerailization( ) {
          _interalDictionary = new Dictionary<TKey, TValue>( );
        }
    
    
    
    
        #endregion
    
        #region implementation of IDictionary<TKey, TValue> interface
    
    
    
        public TValue this[ TKey key ] {
          get {
            try {
              return ( TValue )_interalDictionary[ key ];
            }
            catch( Exception ex ) {
              return default( TValue );
            }
          }
    
          set {
            _interalDictionary[ key ] = value;
            NotifyObserversOfChange( );
          }
        }
    
        public ICollection<TKey> Keys {
          get {
            return _interalDictionary.Select( x => ( TKey )x.Key ).ToList( );
          }
        }
    
        public ICollection<TValue> Values {
          get {
            return _interalDictionary.Select( x => ( TValue )x.Value ).ToList( );
          }
        }
    
        public int Count {
          get {
            return _interalDictionary.Count;
          }
        }
    
        public bool IsReadOnly {
          get {
            return false;
          }
        }
    
        public void Add( TKey key, TValue value ) {
          _interalDictionary.Add( key, value );
          NotifyObserversOfChange( );
        }
    
        public void Add( KeyValuePair<TKey, TValue> item ) {
          _interalDictionary.Add( item.Key, item.Value );
          NotifyObserversOfChange( );
        }
    
        public void Clear( ) {
          _interalDictionary = new Dictionary<TKey, TValue>( );
          NotifyObserversOfChange( );
        }
    
        public bool Contains( KeyValuePair<TKey, TValue> item ) {
    
          return _interalDictionary.Contains( item );
        }
    
        public bool ContainsKey( TKey key ) {
    
          return _interalDictionary.ContainsKey( key );
        }
    
        public void CopyTo( KeyValuePair<TKey, TValue>[ ] array, int arrayIndex ) {
          throw new NotImplementedException( );
        }
    
        public bool Remove( TKey key ) {
          try {
            _interalDictionary.Remove( key );
            NotifyObserversOfChange( );
            return true;
          }
          catch( Exception ex ) {
            return false;
          }
    
        }
    
        public bool Remove( KeyValuePair<TKey, TValue> item ) {
          try {
            _interalDictionary.Remove( item.Key );
            NotifyObserversOfChange( );
            return true;
          }
          catch( Exception ex ) {
            return false;
          }
        }
    
        public bool TryGetValue( TKey key, out TValue value ) {
          try {
            value = ( TValue )_interalDictionary[ key ];
            return true;
          }
          catch( Exception ex ) {
            value = default( TValue );
            return false;
          }
        }
    
        IEnumerator IEnumerable.GetEnumerator( ) {
          return ( ( IDictionary<TKey, TValue> )this ).GetEnumerator( );
        }
    
        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator( ) {
          return _interalDictionary.GetEnumerator( );
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
              propertyHandler( this, new PropertyChangedEventArgs( "this" ) );
            }
          }
        }
    
        public IEnumerator GetEnumerator( ) {
          throw new NotImplementedException( );
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
    
