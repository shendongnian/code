    Mode = 0; // default value now is empty
    for(int i = 0; i < args.Length; i++) {
        switch(args[i])
        {
            case "--a":
                Mode |= Flags.A;
                break;
       
            case "--b":
                Mode |= Flags.B;
                break;
        }
    }
    if(Mode == null)
    {
        Mode = Flags.A | Flags.B; // if no parameters are given, setup both flags
    }
