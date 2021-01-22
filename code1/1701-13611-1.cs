	using System;
	using System.Reflection;
	namespace FunWithEnum
	{
		enum Coolness : byte
		{
			[Description("Not so cool")]
			NotSoCool = 5,
			Cool, // since description same as ToString no attr are used
			[Description("Very cool")]
			VeryCool = NotSoCool + 7,
			[Description("Super cool")]
			SuperCool
		}
		class Description : Attribute
		{
			public string Text;
			public Description(string text)
			{
				Text = text;
			}
		}
		class Program
		{
			static string GetDescription(Enum en)
			{
				Type type = en.GetType();
				MemberInfo[] memInfo = type.GetMember(en.ToString());
				if (memInfo != null && memInfo.Length > 0)
				{
					object[] attrs = memInfo[0].GetCustomAttributes(typeof(Description), false);
					if (attrs != null && attrs.Length > 0)
						return ((Description)attrs[0]).Text;
				}
				return en.ToString();
			}
			static void Main(string[] args)
			{
				Coolness coolType1 = Coolness.Cool;
				Coolness coolType2 = Coolness.NotSoCool;
				Console.WriteLine(GetDescription(coolType1));
				Console.WriteLine(GetDescription(coolType2));
			}
		}
	}
