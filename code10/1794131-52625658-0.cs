        string lowerChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
		string[] lowerCharsArr = lowerChars.Split(sep);
        string upperChars = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
		string[] upperCharsArr = upperChars.Split(sep);
        string numbers = "1,2,3,4,5,6,7,8,9,0";
		string[] numbersArr = numbers.Split(sep);
		string others = "!,@,#,$,%,&,?";
		string[] othersArr = others.Split(sep);
        string passwordString = "";
        int PasswordLength = 16;
        Random rand = new Random();
		passwordString += upperChars[rand.Next(0, upperChars.Length)];
		
        for (int i = 1; i < Convert.ToInt32(PasswordLength -4); i++)
        {
            passwordString += lowerChars[rand.Next(0, lowerChars.Length)];
        }
		for (int i = 0; i < 4; i++)
        {
            passwordString += numbersArr[rand.Next(0, numbersArr.Length)];
        }
