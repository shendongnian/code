        string rand = "ssrpcgg4b3c";
    	string rand1 = "uqb1idvly03";
        byte[] bytes = Encoding.ASCII.GetBytes(rand);
    	byte[] bytes1 = Encoding.ASCII.GetBytes(rand1);
        BigInteger b = new BigInteger(bytes);
    	BigInteger b1 = new BigInteger(bytes1);
    	BigInteger result = b & b1;
