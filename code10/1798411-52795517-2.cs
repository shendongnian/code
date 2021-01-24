    static void Main(string[] args)  
    {  
        var bankAccount = new BankAccount();  
        ICollection<ValidationResult> lstvalidationResult;  
      
        bool valid = GenericValidator.TryValidate(bankAccount, out lstvalidationResult);  
        if (!valid)  
        {  
            foreach (ValidationResult res in lstvalidationResult)  
            {  
                Console.WriteLine(res.MemberNames +":"+ res.ErrorMessage);  
            }  
              
        }  
        Console.ReadLine();  
    }  
