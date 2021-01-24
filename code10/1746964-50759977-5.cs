    // Let's rename board into value...
    static int CheckMove(Sym[,] value, int a, int b, bool cpuTurn) {
      // ... in order to preserve all the other code:
      // we are now working with the copy of the passed board
      Sym[,] board = value.Clone() as Sym[,];
      // Your code from CheckMove here
      ... 
    } 
