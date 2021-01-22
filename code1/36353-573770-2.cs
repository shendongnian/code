    public class Primes {
       private const int _blockSize = 3000000;
       private List<long> _primes;
       private long _next;
       public Primes() {
          _primes = new List<long>() { 2, 3, 5, 7, 11, 13, 17, 19 };
          _next = 23;
       }
       private void Expand() {
          bool[] sieve = new bool[_blockSize];
          foreach (long prime in _primes) {
             for (long i = ((_next + prime - 1L) / prime) * prime - _next;
                i < _blockSize; i += prime) {
                sieve[i] = true;
             }
          }
          for (int i = 0; i < _blockSize; i++) {
             if (!sieve[i]) {
                _primes.Add(_next);
                for (long j = i + _next; j < _blockSize; j += _next) {
                   sieve[j] = true;
                }
             }
             _next++;
          }
       }
       public long this[int index] {
          get {
             if (index < 0) throw new IndexOutOfRangeException();
             while (index >= _primes.Count) {
                Expand();
             }
             return _primes[index];
          }
       }
       public bool IsPrime(long number) {
          while (_primes[_primes.Count - 1] < number) {
             Expand();
          }
          return _primes.BinarySearch(number) >= 0;
       }
    }
