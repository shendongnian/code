    PipeSecurity pipeSecurity = CreateSystemIOPipeSecurity();
    pipeServer = new NamedPipeServerStream(pipeName,
                                           PipeDirection.InOut,
                                           1,
                                           PipeTransmissionMode.Message,
                                           PipeOptions.Asynchronous,
                                           0x4000,
                                           0x400,
                                           pipeSecurity,
                                           HandleInheritability.Inheritable);
