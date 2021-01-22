    public class LoginOutput{
    
    private bool _isLoginSuccess=false;
    public bool IsLoginSuccess{/*Usual get set block*/}
    
    private string _successRedirectUrl = String.Empty();
    public string SuccessRedirectUrl{/*Usual get set block*/}
    
    public IValidationDictionary ValidationResultDict{/*Usual get set block*/}
    }
    
    //your method now could be
    
    public LoginOutput Login(string username, string password){
    // your logic goes here
    }
