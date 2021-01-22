    private int[] getNumbers(int arbitraryN) {
        if (arbitraryN > 270>
           throw new Exception("Arbitrary N has to be at most 270");
        int[] vals = new int[30]; //can be initialized to 1's..
        int nextIdx = 0;
        int nextNumber=0;
        while (vals.Sum() < arbitraryN)
        { 
            nextNumber = new Random().Next(8)+1;
            nextIdx = new Random(unchecked((int) (DateTime.Now.Ticks ))).Next(29);
            vals[nextIdx] = nextNumber;
            if (vals.Sum() > arbitraryN)
                vals[nextIdx] = 0; //if 0 is not feasible, set it to 1..
        }
        return vals;
    }
