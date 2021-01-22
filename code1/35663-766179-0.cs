    // This file defines an internal class used to throw exceptions in BCL code.
    // The main purpose is to reduce code size. 
    // 
    // The old way to throw an exception generates quite a lot IL code and assembly code.
    // Following is an example:
    //     C# source
    //          throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
    //     IL code:
    //          IL_0003:  ldstr      "key"
    //          IL_0008:  ldstr      "ArgumentNull_Key"
    //          IL_000d:  call       string System.Environment::GetResourceString(string)
    //          IL_0012:  newobj     instance void System.ArgumentNullException::.ctor(string,string)
    //          IL_0017:  throw
    //    which is 21bytes in IL.
    // 
    // So we want to get rid of the ldstr and call to Environment.GetResource in IL.
    // In order to do that, I created two enums: ExceptionResource, ExceptionArgument to represent the
    // argument name and resource name in a small integer. The source code will be changed to 
    //    ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key, ExceptionResource.ArgumentNull_Key);
    //
    // The IL code will be 7 bytes.
    //    IL_0008:  ldc.i4.4
    //    IL_0009:  ldc.i4.4
    //    IL_000a:  call       void System.ThrowHelper::ThrowArgumentNullException(valuetype System.ExceptionArgument)
    //    IL_000f:  ldarg.0
    //
    // This will also reduce the Jitted code size a lot. 
