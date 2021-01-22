		string str = "some string";
		Console.WriteLine(str);
		unsafe
		{
			fixed(char *s = str)
			{
				char *c = s;
				while(*c != '\0')
				{
					*c = Char.ToUpper(*c++);					
				}
			}
		}
		Console.WriteLine(str);
