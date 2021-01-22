    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    
    namespace FileOperation1
    {
        class FileMain
        {
            static void Main(string[] args)
            {
                FileMain fm = new FileMain();
                char ch = fm.Menu();
                while (ch != '0')
                {
                    switch (ch)
                    {
                        case '0':
                            break;
                        case '1':
                            //Console.WriteLine("This featute is not implemented till now.");
                            break;
                        case '2':
                            Console.Write("Enter the name of the file: ");
                            String FileName = Console.ReadLine();// ReadLine() method is not workin here
                            FileOperation Fo = new FileOperation();
                            Console.WriteLine("\n" + Fo.FileRead(FileName, FileMode.Open, FileAccess.Read));
                            break;
                        case '3':
                            //Console.WriteLine("This featute is not implemented till now.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Enter again.");
                            break;
                    }
                    ch = fm.Menu();
                }
            }
            private char Menu()
            {
                Console.WriteLine("\n\t***File Operations***");
                Console.WriteLine("1. Create a new file");
                Console.WriteLine("2. Open a file");
                Console.WriteLine("3. Edit an existing file");
                Console.WriteLine("0. Exit");
                Console.Write("\nEnter your choice: ");
                char ch = Convert.ToChar(Console.ReadLine()); //Read() Method is not working properly
                return ch;
            }
        }
        public class FileOperation
        {
            private String FileRead(FileStream Fs)
            {
                StreamReader Sr = new StreamReader(Fs);
                Sr.BaseStream.Seek(0, SeekOrigin.Begin);
                String str = "" + (Char)Sr.Read();
                String ret = "";
                while (!Sr.EndOfStream)
                {
                    ret += str;
                    str = "" + (Char)Sr.Read();
                }
                Sr.Close();
                return ret;
            }
            public String FileRead(String FileName, FileMode Fm, FileAccess Fa)
            {
                FileOperation Fo = new FileOperation();
                FileStream Fs = new FileStream(FileName, Fm, Fa);
                String ret = Fo.FileRead(Fs);
                Fs.Close();
                return ret;
            }
        }
    }
