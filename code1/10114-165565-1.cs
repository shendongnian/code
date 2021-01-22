    private bool CheckSuspendersAndBelt()
    {
        try
        {
            //ensure that true is true...
            if (true == true)
            {
                //...and that false is false...
                if (false == false)
                {
                    //...and that true and false are not equal...
                    if (false != true)
                    {
                        //don't proceed if we don't have at least one processor
                        if (System.Environment.ProcessorCount > 0)
                        {
                            //and if there is no system directory then something is wrong
                            if (System.Environment.SystemDirectory != null)
                            {
                                //hopefully the code is running under some version of the CLR...
                                if (System.Environment.Version != null)
                                {
                                    //we don't want to proceed if we're not in a process...
                                    if (System.Diagnostics.Process.GetCurrentProcess() != null)
                                    {
                                        //and code running without a thread would not be good...
                                        if (System.Threading.Thread.CurrentThread != null)
                                        {
                                            //finally, make sure instantiating an object really results in an object...
                                            if (typeof(System.Object) == (new System.Object()).GetType())
                                            {
                                                //good to go
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        catch
        {
            return false;
        }
    }
