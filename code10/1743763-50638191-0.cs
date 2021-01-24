    #region Assembly Microsoft.EntityFrameworkCore, Version=2.0.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
    // C:\Users\myname\.nuget\packages\microsoft.entityframeworkcore\2.0.1\lib\netstandard2.0\Microsoft.EntityFrameworkCore.dll
    #endregion
    
    using JetBrains.Annotations;
    
    namespace Microsoft.EntityFrameworkCore
    {
        //
        // Summary:
        //     Provides CLR methods that get translated to database functions when used in LINQ
        //     to Entities queries. The methods on this class are accessed via Microsoft.EntityFrameworkCore.EF.Functions.
        public static class DbFunctionsExtensions
        {
            //
            // Summary:
            //     An implementation of the SQL LIKE operation. On relational databases this is
            //     usually directly translated to SQL.
            //
            // Parameters:
            //   _:
            //     The DbFunctions instance.
            //
            //   matchExpression:
            //     The string that is to be matched.
            //
            //   pattern:
            //     The pattern which may involve wildcards %,_,[,],^.
            //
            // Returns:
            //     true if there is a match.
            public static bool Like([CanBeNull] this DbFunctions _, [CanBeNull] string matchExpression, [CanBeNull] string pattern);
            //
            // Summary:
            //     An implementation of the SQL LIKE operation. On relational databases this is
            //     usually directly translated to SQL.
            //
            // Parameters:
            //   _:
            //     The DbFunctions instance.
            //
            //   matchExpression:
            //     The string that is to be matched.
            //
            //   pattern:
            //     The pattern which may involve wildcards %,_,[,],^.
            //
            //   escapeCharacter:
            //     The escape character (as a single character string) to use in front of %,_,[,],^
            //     if they are not used as wildcards.
            //
            // Returns:
            //     true if there is a match.
            public static bool Like([CanBeNull] this DbFunctions _, [CanBeNull] string matchExpression, [CanBeNull] string pattern, [CanBeNull] string escapeCharacter);
        }
    }
