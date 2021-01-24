    Regex rx = new Regex(@"(?:(?<![)0-9])-)?[0-9]+(?:\.[0-9]+)?");
	string expression = "((-30+5.2)*(2+7))-((-3.1*2.5)-9.12)";
	char letter = (char)96; // char before a in ASCII table
	string result = rx.Replace(expression, m => 
		{
			letter++;       // char is incremented
			return letter.ToString();
		}
	);
	Console.WriteLine(result); // => ((a+b)*(c+d))-((e*f)-g)
