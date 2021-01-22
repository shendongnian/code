    class Test {
       private int _checksum = -1;
       private int Checksum {
          get {
             if (_checksum == -1)
                _checksum = calculateChecksum();
             return checksum;
          }
       }
    }
