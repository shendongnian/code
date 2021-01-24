    public static implicit operator C(bool b)
    {
        System.Console.WriteLine("C implicit conversion from bool");
        return new C();
    }
