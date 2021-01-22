    class Role {
        public Role(Person p) { p.liRoles.Add(this); }
    }
    class Partner : Role {
        public Partner(Person p) : base(p) {}
    }
    class Person { 
        List<IRole> liRoles;
        public T As<T>() { 
            foreach(IRole r in liRoles){ if r is T return r; }
            return null;
        }
        public bool Is<T>() { return As<T>() != null; }
    }
    var p = new Person();
    var pa = new Partner(p);
