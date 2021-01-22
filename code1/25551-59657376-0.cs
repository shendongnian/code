    /A                                  // namespace: A
      /B                                // namespace: A.B
        /C                              // namespace: A.B.C
          A.B.C.csproj 
          ClassC.cs                  
          /_                            // External Namespace root folder (underscore with not text)
            /System                     // namespace: System 
              /Linq                     // namespace: System.Linq
                IQueryableExtensions.cs 
            /Microsoft                  // namespace: Microsoft
              /Extensions               // namespace: Microsoft.Extensions
                /Logging                // namespace: Microsoft.Extensions.Logging
                  ILoggerExtensions.cs                                  
          /__A                          // namespace: A (Grand Parent folder (2 underscores for 2 levels up)
            ClassAExtensions.cs
            /B                          // namespace: A.B (Nested Parent folder)
              ClassBExtensionsNested.cs
                                        //Parent Namespace folder (1 underscore for 1 level up)
          /_B                           // namespace: A.B
            ClassBExtensions.cs
          /D                            // namespace: A.B.C.D (Child folder)
            ClassDExtensions.cs
       
