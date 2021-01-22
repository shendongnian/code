      class Pair<TCar, TCdr>
      {
        public TCar Car { get; set; }
        public TCdr Cdr { get; set; }
      }
    
      class List<T> : Pair<T, List<T>>, IEnumerable<T>
      {
        public List(T car, List<T> cdr)
        {
          Car = car;
          Cdr = cdr;
        }
    
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
          yield return Car;
          var cdr = Cdr;
          while (cdr != null)
          {
            yield return cdr.Car;
            cdr = cdr.Cdr;
          }
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
          return ((IEnumerable<T>)this).GetEnumerator();
        }
      }
