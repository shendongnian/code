    long factorial(int i){
        //Cache array
        static long factorials[1000];
        if (!factorials[i]){ //If not cached, calculate & store
            int product = 1;
            for (int idx = 1; idx <= i + 1; ++idx){
                product *= idx;
            }
            factorials[i] = product;
        }
        return factorials[i]; //Return cached value
    }
