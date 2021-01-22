        long remaining = 2147483647;// max theoretical format arg length
        long count = 10; // i.e. {0}-{9}
        long len = 1;
        int total = 0;
        while (remaining >= 0) {
            for(int i = 0 ; i < count && remaining >= 0; i++) {
                total++;
                remaining -= len + 2; // allow for {}
            }
            count *= 10;
            len++;
        }
        
        Console.WriteLine(total - 1);
