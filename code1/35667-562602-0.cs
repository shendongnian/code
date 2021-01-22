    class Address1
    {
        public string name = "Address1";
    }
    class Address2
    {
        public string name = "Address2";
    }
    class GenericAddress
    {
        public string name = "GenericAddress";
        public static implicit operator GenericAddress(Address1 a)
        {
            GenericAddress p = new GenericAddress(); p.name = a.name; return p;
        }
        public static implicit operator GenericAddress(Address2 a)
        {
            GenericAddress p = new GenericAddress(); p.name = a.name; return p;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PrintName(new Address1());//prints address1
            PrintName(new Address2());//prints address2
        }
        static void PrintName(GenericAddress a)
        {
            Console.WriteLine(a.name);
        }
    }
