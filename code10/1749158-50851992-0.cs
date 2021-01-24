    int value1 = 'a';           //First converts to ASCII value 97 and then stored in value1
    char value2 ='a';           //Stored as a
    Console.WriteLine(value1);  //output is 97
    Console.WriteLine(value2);  //output is a
    Console.WriteLine(value1 == value2);   //compares using implicit conversion. Since value type, so only value comparison and hence true 
    Console.WriteLine('a' == 97);          //compares using implicit conversion.  Since value type, so only value comparison and hence true  
    Console.WriteLine(value1.Equals(value2)); //compares using implicit conversion.  Since value type, so only value comparison and hence true 
