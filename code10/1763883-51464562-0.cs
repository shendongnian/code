    public int Mult27(int a)
    {
		return ADD(ADD(SHL(a, 4), SHL(a, 3)), SUB(SHL(a, 2), a));
    }
	var ae = new AnswerEleven();
	Console.WriteLine(ae.Mult27(1));
	Console.WriteLine(ae.Mult27(2));
