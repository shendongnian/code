        int password; 
        int repassword
        
        Do{
        Console.WriteLine("\n Enter the password");
        password= int.Parse(Console.ReadLine()); //first password
        string ps = Convert.ToString(password);
        }while(ps.Length!=4) //request the password if is not composed by 4 digits
        
        //menu part//
        Do{
        Console.WriteLine("\n Reinsert the password");
        repassword= int.Parse(Console.ReadLine()); //reinsert password
        } while(repassword!=password)
       
