    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		// Passwords
    		String[] passwords = new String[8];
    		
    		passwords[0] = "ABCabc123";    //  letters (uppercase or lowercase) and numbers                           : VALID
    		passwords[1] = "*+uu*+aa";     //  letters (uppercase or lowercase) and special characters                : VALID
    		passwords[2] = "123+*$0*";      //  numbers and special characters                                        : VALID
    		passwords[3] = "ABCabc123*$#"; //  letters (uppercase or lowercase) and numbers and special characters    : VALID
    		passwords[4] = "ABCDabcd";     //  letters (uppercase and lowercase)                                      : INVALID
    		passwords[5] = "abcdefg";      //  letters (lowercase)												      : INVALID
    		passwords[6] = "ABCDEFGH";     //  letters (uppercase)												      : INVALID
    		passwords[7] = "123456789";	  //  numbers															      : INVALID
    
    		// Password validation  pattern
    		var hasLetterAndNumber = new Regex(@"((?=.*[A-Z])|(?=.*[a-z]))(?=.*[0-9]).{8,32}");
    		var hasLetterAndCharacter = new Regex(@"((?=.*[A-Z])|(?=.*[a-z]))(?=.*[@#$%^&+=]).{8,32}");
    		var hasNumberAndCharacter = new Regex(@"(?=.*[0-9])(?=.*[@#$%^&+=]).{8,32}");
    
    		// Validat the passwords
    		for (int i = 0; i < passwords.Length; i++){
    			
    			if((hasLetterAndNumber.IsMatch(passwords[i])) || (hasLetterAndCharacter.IsMatch(passwords[i])) || (hasNumberAndCharacter.IsMatch(passwords[i]))){
    				Console.WriteLine(passwords[i]);
    				Console.WriteLine("\n");
    			}
    		}
    	}
    }
