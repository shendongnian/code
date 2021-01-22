    public class a<T> where T : DTOa {
        private readonly T _DTO = Activator.CreateInstance<T>();
        protected T DTO { get { return this._DTO; } }
        //properties
    }
    public class b<T> : a<T> where T : DTOb {
        //NB: Don't override or hide DTO.
        //properties
    }
    var a = new a<DTOa>();
    var b = new b<DTOb>();
    b.Id = 100;
    b.FirstName = "Jim";
    b.Email = "email@email.com";
    b.Password = "test";
