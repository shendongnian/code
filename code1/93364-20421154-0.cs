    static IEnumerable<int> primes(uint top_number) {
      var cullbf = Enumerable.Range(2, (int)top_number).ToList();
      for (int i = 0; i < cullbf.Count; i++) {
        var bp = cullbf[i]; var sqr = bp * bp; if (sqr > top_number) break;
        cullbf.RemoveAll(c => c >= sqr && c % bp == 0);
      } return cullbf; }
