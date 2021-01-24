    using Diagnostics.Tracing;
    using Diagnostics.Tracing.Parsers;
    using System;
    using System.Diagnostics;
    using System.IO;
    
    namespace ProcessMonitor
    {
    
        /// <summary>
        /// The main program monitors processes (and image loads) using ETW.  
        /// </summary>
        class Program
        {
            /// <summary>
            /// This is a demo of using TraceEvent to activate a 'real time' provider that is listening to 
            /// the MyEventSource above.   Normally this event source would be in a differnet process,  but 
            /// it also works if this process generate the evnets and I do that here for simplicity.  
            /// </summary>
            static int Main(string[] args)
            {
                // Today you have to be Admin to turn on ETW events (anyone can write ETW events).   
                if (!(TraceEventSession.IsElevated() ?? false))
                {
                    Console.WriteLine("To turn on ETW events you need to be Administrator, please run from an Admin process.");
                    return -1;
                }
    
                // As mentioned below, sessions can outlive the process that created them.  Thus you need a way of 
                // naming the session so that you can 'reconnect' to it from another process.   This is what the name
                // is for.  It can be anything, but it should be descriptive and unique.   If you expect mulitple versions
                // of your program to run simultaneously, you need to generate unique names (e.g. add a process ID suffix) 
                var sessionName = "ProessMonitorSession";
                using (var session = new TraceEventSession(sessionName, null))  // the null second parameter means 'real time session'
                {
                    // Note that sessions create a OS object (a session) that lives beyond the lifetime of the process
                    // that created it (like Filles), thus you have to be more careful about always cleaning them up. 
                    // An importanty way you can do this is to set the 'StopOnDispose' property which will cause the session to 
                    // stop (and thus the OS object will die) when the TraceEventSession dies.   Because we used a 'using'
                    // statement, this means that any exception in the code below will clean up the OS object.   
                    session.StopOnDispose = true;
    
                    // By default, if you hit Ctrl-C your .NET objects may not be disposed, so force it to.  It is OK if dispose is called twice.
                    Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e) { session.Dispose(); };
    
                    // prepare to read from the session, connect the ETWTraceEventSource to the session
                    using (var source = new ETWTraceEventSource(sessionName, TraceEventSourceType.Session))
                    {
                        Action<TraceEvent> action = delegate(TraceEvent data)
                        {
                            // Console.WriteLine("GOT EVENT: " + data.ToString());
                            var taskName = data.TaskName;
                            if (taskName == "ProcessStart" || taskName == "ProcessStop") 
                            {
                                string exe = (string) data.PayloadByName("ImageName");
                                string exeName = Path.GetFileNameWithoutExtension(exe);
    
                                int processId = (int) data.PayloadByName("ProcessID");
                                if (taskName == "ProcessStart")
                                {
                                    int parentProcessId = (int)data.PayloadByName("ParentProcessID");
                                    Console.WriteLine("{0:HH:mm:ss.fff}: {1,-12}: {2} ID: {3} ParentID: {4}", 
                                        data.TimeStamp, taskName, exeName, processId, parentProcessId);
                                }
                                else
                                {
                                    int exitCode = (int) data.PayloadByName("ExitCode");
                                    long cpuCycles = (long) data.PayloadByName("CPUCycleCount");
                                    Console.WriteLine("{0:HH:mm:ss.fff}: {1,-12}: {2} ID: {3} EXIT: {4} CPU Cycles: {5:n0}",
                                        data.TimeStamp, taskName, exeName, processId, exitCode, cpuCycles);
                                }
                            }
                        };
    
                        // Hook up the parser that knows about Any EventSources regsitered with windows.  (e.g. the OS ones. 
                        var registeredParser = new RegisteredTraceEventParser(source);
                        registeredParser.All += action;
    
                        // You can also simply use 'logman query providers' to find out the GUID yourself and wire it in. 
                        var processProviderGuid = TraceEventSession.GetProviderByName("Microsoft-Windows-Kernel-Process");
                        if (processProviderGuid == Guid.Empty)
                        {
                            Console.WriteLine("Error could not find Microsoft-Windows-Kernel-Process etw provider.");
                            return -1;
                        }
    
                        // Using logman query providers Microsoft-Windows-Kernel-Process I get 
                        //     0x0000000000000010  WINEVENT_KEYWORD_PROCESS
                        //     0x0000000000000020  WINEVENT_KEYWORD_THREAD
                        //     0x0000000000000040  WINEVENT_KEYWORD_IMAGE
                        //     0x0000000000000080  WINEVENT_KEYWORD_CPU_PRIORITY
                        //     0x0000000000000100  WINEVENT_KEYWORD_OTHER_PRIORITY
                        //     0x0000000000000200  WINEVENT_KEYWORD_PROCESS_FREEZE
                        //     0x8000000000000000  Microsoft-Windows-Kernel-Process/Analytic
                        // So 0x10 is WINEVENT_KEYWORD_PROCESS
                        session.EnableProvider(processProviderGuid, TraceEventLevel.Informational, 0x10);
    
                        Console.WriteLine("Starting Listening for events");
                        // go into a loop processing events can calling the callbacks.  Because this is live data (not from a file)
                        // processing never completes by itself, but only because someone called 'source.Close()'.  
                        source.Process();
                        Console.WriteLine();
                        Console.WriteLine("Stopping Listening for events");
                    }
                }
                return 0;
            }
        }
    
    }
