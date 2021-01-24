        try
        {
            DoSomethingHard();
        }
        catch (MyException1 exception1)
        {
            _log.Write("Warning: small exception, no worries. {0}", exception1.Message);
            continue;
        }
        catch (MyException2 exception2)
        {
            _log.Write("Fatal: big exception, gotta bail out now. {0}", exception2.Message);
            break;
        }    
            
