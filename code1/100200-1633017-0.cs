    // default.cs
    // ------------------------------------------------------------------
    //
    // Description goes here....
    // 
    // Author: MyUser
    // built on host: MyMachine
    // Created Tue Oct 27 15:01:18 2009
    //
    // last saved: 
    // Time-stamp: <2009-October-20 00:18:52>
    // ------------------------------------------------------------------
    //
    // Copyright Notice here
    // All rights reserved!
    //
    // ------------------------------------------------------------------
    using System;
    using System.Reflection;
    // to allow fast ngen
    [assembly: AssemblyTitle("default.cs")]
    [assembly: AssemblyDescription("insert purpose here")]
    [assembly: AssemblyConfiguration("")]
    [assembly: AssemblyCompany("Dino Chiesa")]
    [assembly: AssemblyProduct("Tools")]
    [assembly: AssemblyCopyright("Copyright notice again")]
    [assembly: AssemblyTrademark("")]
    [assembly: AssemblyCulture("")]
    [assembly: AssemblyVersion("1.1.1.1")]
    namespace Cheeso.ToolsAndTests
    {
      public class default
      {
        // ctor
        public default () {}
        string _positionalParam1;
        string _param1;
        int _intParam = DefaultIntParamValue;
        bool _flag1;
        private readonly int DefaultIntParamValue = -99;
        // ctor
        public default (string[] args)
        {
            for (int i=0; i < args.Length; i++)
            {
                switch (args[i])
                {
                case "-stringArg":
                    i++;
                    if (args.Length <= i) throw new ArgumentException(args[i]);
                    _param1 = args[i];
                    break;
                case "-intArg":
                    i++;
                    if (args.Length <= i) throw new ArgumentException(args[i]);
                    if (_intParam != DefaultIntParamValue)
                        throw new ArgumentException(args[i]);
                    if (args[i].StartsWith("0x"))
                        _intParam = System.Int32.Parse(args[i].Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier );
                    else
                        _intParam = System.Int32.Parse(args[i]);
                    break;
                case "-boolarg":
                    _flag1 = true;
                    break;
                case "-?":
                    throw new ArgumentException(args[i]);
                default:
                    if (_positionalParam1 != null)
                        throw new ArgumentException(args[i]);
                    _positionalParam1 = args[i];
                    break;
                }
            }
            // default values
            if (_positionalParam1 == null)
                _positionalParam1 = "default.value.for.positional.param";
            if (_param1 == null)
                _param1 = "default.value.for.param1";
            if (_param2 == 0)
                _param2 = DEFAULT_value_for_param2;
        }
        public void Run()
        {
        }
        public static void Usage()
        {
            Console.WriteLine("\ndefault: <usage statement here>.\n");
            Console.WriteLine("Usage:\n  default [-arg1 <value>] [-arg2]");
        }
        public static void Main(string[] args)
        {
          try 
          {
            new default(args)
                .Run();
          }
          catch (System.Exception exc1)
          {
            Console.WriteLine("Exception: {0}", exc1.ToString());
            Usage();
          }
        }
      }
    }
