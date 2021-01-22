    #define System_ComponentModel
    #undef  System_Drawing
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #if System_ComponentModel
    using System.ComponentModel;
    #endif
    #if System_Drawing
    using System.Drawing;
    #endif
    namespace MyCompany.Extensions
    {
        static partial class MyExtensions
        {
            // other #Region blocks are removed. i use many in my Extensions
            // module/class. the below code is only the 2 relevant extension
            // for this 'SafeInvoke' functionality. but i use other regions
            // such as "String extensions" and "Numeric extensions". i use
            // the above System_ComponentModel and System_Drawing compiler
            // directives to include or exclude blocks of code that i want
            // to either include or exclude in a project, which allows me to
            // easily compare my code in one project with the same file in
            // other projects to syncronise new changes across projects.
            // you can scrap pretty much all the code above,
            // but i'm giving it here so you see it in the full context.
            #region ISynchronizeInvoke extensions
    #if System_ComponentModel
            public static TResult SafeInvoke<T, TResult>(this T isi, Func<T, TResult> callFunction) where T : ISynchronizeInvoke
            {
                if (isi.InvokeRequired)
                {
                    IAsyncResult result = isi.BeginInvoke(callFunction, new object[] { isi });
                    object endResult = isi.EndInvoke(result); return (TResult)endResult;
                }
                else
                    return callFunction(isi);
            }
            /// <summary>
            /// This can be used in C# with:
            /// txtMyTextBox.SafeInvoke(d => d.Text = "This is my new Text value.");
            /// or:
            /// txtMyTextBox.SafeInvoke(d => d.Text = myTextStringVariable);
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="isi"></param>
            /// <param name="callFunction"></param>
            public static void SafeInvoke<T>(this T isi, Action<T> callFunction) where T : ISynchronizeInvoke
            {
                if (isi.InvokeRequired) isi.BeginInvoke(callFunction, new object[] { isi });
                else
                    callFunction(isi);
            }
    #endif
            #endregion
            // other #Region blocks are removed from here too.
        } // static class MyExtensions
    } // namespace
