        for (int i=0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "-f":  // string data
                    i++;
                    if (args.Length <= i) throw new ArgumentException(args[i]);
                    _file = args[i];
                    break;
        
                case "-p":  // boolean flag
                    _pflag= true;
                    break;
                
                case "-i":  // int argument, allows hex or decimal
                    i++;
                    if (args.Length <= i) throw new ArgumentException(args[i]);
                    if (_intParam != DefaultIntParamValue)
                        throw new ArgumentException(args[i]);
                    if (args[i].StartsWith("0x"))
                        _intParam = System.Int32.Parse(args[i].Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier );
                    else
                        _intParam = System.Int32.Parse(args[i]);
                    break;
        
        
                case "-s":  // size, in bytes, K, MB, GB
                    i++;
                    if (args.Length <= i) throw new Exception(args[i-1]);
                    if (args[i].ToUpper().EndsWith("K"))
                        _size = System.Int32.Parse(args[i].Substring(0,args[i].Length-1)) * 1024;
                    else if (args[i].ToUpper().EndsWith("KB"))
                        _size = System.Int32.Parse(args[i].Substring(0,args[i].Length-2)) * 1024;
                    else if (args[i].ToUpper().EndsWith("M"))
                        _size = System.Int32.Parse(args[i].Substring(0,args[i].Length-1)) * 1024*1024;
                    else if (args[i].ToUpper().EndsWith("MB"))
                        _size = System.Int32.Parse(args[i].Substring(0,args[i].Length-2)) * 1024*1024;
                    else
                        _size = Int32.Parse(args[i]);
                    break;
              
        
                case "-?":
                    throw new ArgumentException(args[i]);
        
                default:  // positional argument
                    if (_positionalArg != null)
                        throw new ArgumentException(args[i]);
        
                    _positionalArg = args[i];
                    break;
            }
        }
        
