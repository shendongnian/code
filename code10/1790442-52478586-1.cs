    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        enum DEFINE_STATE
        {
            FOUND_DEFINE,
            FIND_DEFINE
        }
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                string pattern = "#include\\s+\"test.h\"";
                StreamReader reader = new StreamReader(FILENAME);
                string input = "";
                DEFINE_STATE state = DEFINE_STATE.FIND_DEFINE;
                int line_number = 0;
                int defineLine_Number = 0;
                Boolean foundInclude = false;
                while((input = reader.ReadLine()) != null)
                {
                    line_number++;
                    switch (state)
                    {
                        case DEFINE_STATE.FIND_DEFINE :
                            if (input.Contains("#define")) 
                            {
                                state = DEFINE_STATE.FOUND_DEFINE;
                                defineLine_Number = line_number;
                                foundInclude = false;
                            }
                            break;
                        case DEFINE_STATE.FOUND_DEFINE :
                            Match match = Regex.Match(input, pattern);
                            if(match.Success) foundInclude = true;
                            if (input.Contains("#else") || input.Contains("#endif") || input.Contains("#define"))
                            {
                                if (foundInclude == false)
                                {
                                    Console.WriteLine("Define at line {0} does not have and include", defineLine_Number.ToString());
                                }
                                if (input.Contains("#define"))
                                {
                                    defineLine_Number = line_number;
                                    foundInclude = false;
                                }
                                else
                                {
                                    state = DEFINE_STATE.FIND_DEFINE;
                                }
                            }
                            break;
                    }
                }
                Console.ReadLine();
            }
        }
    }
