    // Sets list[destination[i]] = list[i] for all i.  Clobbers destination list.
    void ReorderByDestination(List<T> list, List<int> destination) {
      for (int i = 0; i < list.Count; i++) {
        while (destination[i] != i) {
          int d = destination[i];
          T t = list[d];            // save element in destination slot
          int t_d = destination[d]; // and its own destination
          list[d] = list[i];        // move element to destination
          destination[d] = d;       // and mark it as moved
          list[i] = t;              // store saved element in slot i
          destination[i] = t_d;     // ... and its destination
        }
      }
    }
