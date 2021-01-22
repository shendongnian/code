    class NotInheritable
        {
    
            private NotInheritable()
            {
                //making the constructor private
            }
        }
     class Derived : NotInheritable { }
