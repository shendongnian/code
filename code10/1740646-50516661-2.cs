    public partial class Login: Form
    {
        public bool isLogin=false;//This should be public
        public Login()
        {
            InitializeComponent();
        }
        
    
        private void CheckUsernamePassword(string username,string password){
            if(username=="yourname" && password =="yourpass"){
               isLogin=true;
               this.close();
            }else{
               MessageBox.Show("Wrong username or password");
            }
    
         }
     }
