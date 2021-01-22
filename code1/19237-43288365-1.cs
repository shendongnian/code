    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace CmdArgProcessor
    {
        class Program
        {
            static void Main(string[] args)
            {
                // test switches and switches with values
                // -test1 1 -test2 2 -test3 -test4 -test5 5
                string dummyString = string.Empty;
                var argDict = BurstCmdLineArgs(args);
                Console.WriteLine("Value for switch = -test1: {0}", argDict["test1"]);
                Console.WriteLine("Value for switch = -test2: {0}", argDict["test2"]);
                Console.WriteLine("Switch -test3 is present? {0}", argDict.TryGetValue("test3", out dummyString));
                Console.WriteLine("Switch -test4 is present? {0}", argDict.TryGetValue("test4", out dummyString));
                Console.WriteLine("Value for switch = -test5: {0}", argDict["test5"]);
                // Console output:
                //
                // Value for switch = -test1: 1
                // Value for switch = -test2: 2
                // Switch -test3 is present? True
                // Switch -test4 is present? True
                // Value for switch = -test5: 5
            }
            public static Dictionary<string, string> BurstCmdLineArgs(string[] args)
            {
                var argDict = new Dictionary<string, string>();
                // Flatten the args in to a single string separated by a space.
                // Then split the args on the dash delimiter of a cmd line "switch".
                // E.g. -mySwitch myValue
                //  or -JustMySwitch (no value)
                //  where: all values must follow a switch.
                // Then loop through each string returned by the split operation.
                // If the string can be split again by a space character,
                // then the second string is a value to be paired with a switch,
                // otherwise, only the switch is added as a key with an empty string as the value.
                // Use dictionary indexer to retrieve values for cmd line switches.
                // Use Dictionary::ContainsKey(...) where only a switch is recorded as the key.
                string.Join(" ", args).Split('-').ToList().ForEach(s => argDict.Add(s.Split()[0], (s.Split().Count() > 1 ? s.Split()[1] : "")));
                return argDict;
            }
        }
    }
