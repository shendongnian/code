    static Point Sample0() => new Point().To(out var p).With(
    	p.X = 123,
    	p.Y = 321,
    	p.Name = "abc"
    );
    
    public static Point GetPoint() => new Point { Name = "Point Name" };
    static string NameProperty { get; set; }
    static string NameField;
    
    static void Sample1()
    {
    	string nameLocal;
    	GetPoint().To(out var p).With(
    		p.X = 123,
    		p.Y = 321,
    		p.Name.To(out var name), /* right side assignment to the new variable */
    		p.Name.To(out nameLocal), /* right side assignment to the declared var */
    		NameField = p.Name, /* left side assignment to the declared variable */
    		NameProperty = p.Name /* left side assignment to the property */
    	);
    	
    	Console.WriteLine(name);
    	Console.WriteLine(nameLocal);
    	Console.WriteLine(NameField);
    	Console.WriteLine(NameProperty);
    }
    
    static void Sample2() /* non-null propogation sample */
    {
    	((Point)null).To(out var p)?.With(
    		p.X = 123,
    		p.Y = 321,
    		p.Name.To(out var name)
    	);
    	
    	Console.WriteLine("No exception");
    }
    
    static void Sample3() /* recursion */
    {
    	GetPerson().To(out var p).With(
    		p.Name.To(out var name),
    		p.Subperson.To(out var p0).With(
    			p0.Name.To(out var subpersonName0)
    		),
    		p.GetSubperson().To(out var p1).With( /* method return */
    			p1.Name.To(out var subpersonName1)
    		)
    	);
    	
    	Console.WriteLine(subpersonName0);
    	Console.WriteLine(subpersonName1);
    }
