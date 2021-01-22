       [CookiesActions]
        public ActionResult Login(Usuarios usuario)
        {
         [...]
               Usuarios usarios = new Usuarios();
               try
               {
                 ...
                 usarios = sceUsuarios.Usuario;
     
                }
                catch  { //swallow error }
                return View(new UsersViewModel(usarios ,true));
 
               [...]
        }
