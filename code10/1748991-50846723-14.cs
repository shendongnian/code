    void Main()
    {
    	var a = new A { HP = 100 };
    	var b = new B { HP = 100 };
    	var c = new C { HP = 100 };
    	a.Attack(a); // stop hitting yourself
    	a.Attack(b);
    	a.Attack(c);
    	Console.WriteLine(a.HP); // 85
    	Console.WriteLine(b.HP); // 70
    	Console.WriteLine(c.HP); // 93
    }
