    public class FormProvider
    {
       public static UserForm UserForm
       {
           get
           {
              if (_userForm== null || _userForm.IsDisposed)
              {
                _userForm= new UserForm ();
              }
              return _userForm;
           }
       }
       private static UserForm _userForm;
    }
