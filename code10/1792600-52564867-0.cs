		using System;
		using System.Reflection;
		namespace CountryEnum
		{
			class Program
			{
				static void Main(string[] args)
				{
					// Using enum
					COUNTRY_CODE enum_variable = COUNTRY_CODE.AF;
					Console.WriteLine("Enum variable: " + Program.GetEnumDescription(enum_variable));
					// Have short code string of country as input -> convert it to enum
					string country_code = "AL";
					COUNTRY_CODE convertResult = COUNTRY_CODE.UNKNOWN;
					Enum.TryParse(country_code, out convertResult);
					Console.WriteLine("string variable: " + Program.GetEnumDescription(convertResult));
					Console.ReadLine();
				}
				/// <summary>
				/// GET string description
				/// </summary>
				/// <param name="en"></param>
				/// <returns></returns>
				public static string GetEnumDescription(Enum en)
				{
					Type type = en.GetType();
					try
					{
						MemberInfo[] memInfo = type.GetMember(en.ToString());
						if (memInfo != null && memInfo.Length > 0)
						{
							object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumDisplayString), false);
							if (attrs != null && attrs.Length > 0)
								return ((EnumDisplayString)attrs[0]).DisplayString;
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
					return en.ToString();
				}
			}
			
			public enum COUNTRY_CODE
			{
				[EnumDisplayString("AFGHANISTAN")]
				AF
				,
				[EnumDisplayString("ALBANIA")]
				AL
			   ,
				[EnumDisplayString("UNKNOWN")]
				UNKNOWN
			}
			public class EnumDisplayString : Attribute
			{
				public string DisplayString;
				public EnumDisplayString(string text)
				{
					this.DisplayString = text;
				}
			}
		}
