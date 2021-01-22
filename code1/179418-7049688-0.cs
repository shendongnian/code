		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		namespace ConsoleReadPasswords
		{
			class Program
			{
				static void Main(string[] args)
				{
					Console.Write("Password:");
					string password = Orb.App.Console.ReadPassword();
					Console.WriteLine("Sorry - I just can't keep a secret!");
					Console.WriteLine("Your password was:\n<Password>{0}</Password>", password);
					Console.ReadLine();
				}
			}
		}
		namespace Orb.App
		{
			/// <summary>
			/// Adds some nice help to the console. Static extension methods don't exist (probably for a good reason) so the next best thing is congruent naming.
			/// </summary>
			static public class Console
			{
				/// <summary>
				/// Like System.Console.ReadLine(), only with a mask.
				/// </summary>
				/// <param name="mask">a <c>char</c> representing your choice of console mask</param>
				/// <returns>the string the user typed in </returns>
				public static string ReadPassword(char mask)
				{
					const int ENTER = 13, BACKSP = 8, CTRLBACKSP = 127;
					int[] FILTERED = { 0, 27, 9, 10, 32 }; // const
					var pass = new Stack<char>();
					char chr = (char)0;
					while ((chr = System.Console.ReadKey(true).KeyChar) != ENTER)
					{
						if (chr == BACKSP)
						{
							if (pass.Count > 0)
							{
								System.Console.Write("\b \b");
								pass.Pop();
							}
						}
						else if (chr == CTRLBACKSP)
						{
							while (pass.Count > 0)
							{
								System.Console.Write("\b \b");
								pass.Pop();
							}
						}
						else if (FILTERED.Count(x => chr == x) > 0) { }
						else
						{
							pass.Push((char)chr);
							System.Console.Write(mask);
						}
					}
					System.Console.WriteLine();
					return new string(pass.Reverse().ToArray());
				}
				/// <summary>
				/// Like System.Console.ReadLine(), only with a mask.
				/// </summary>
				/// <returns>the string the user typed in </returns>
				public static string ReadPassword()
				{
					return Orb.App.Console.ReadPassword('*');
				}
			}
		}
