    //step 1 and 2
    byte[] data = System.Text.Encoding.Unicode.GetBytes(tbPassword.Text,);
    byte[] result; 
    
    //step 3
    SHA1 sha = new SHA1CryptoServiceProvider(); 
    result = sha.ComputeHash(data);
    
    //step 4
    string storableHashResult = System.Text.Encoding.Unicode.ToString(result);
    //step 5
        // add your code here
