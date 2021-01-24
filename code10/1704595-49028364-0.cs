    public int AddAll(params int[] input){
        int total = 0; 
        foreach (int i in input){ //loop through all the inputs
            total += i; //same as total = total + i
        }
        return total;
    }
