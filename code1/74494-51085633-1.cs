    using System;
    public class Test
    {
        public static void Main()
        {
            Example("ksEE5A.exe");
        }
        
        public static char Example(string path) {
            var reader = default(System.IO.StreamReader);
            var line = default(string);
            var character = default(char);
            TryElse(
                delegate {
                    Console.WriteLine("Trying to open StreamReader ...");
                    reader = new System.IO.StreamReader(path);
                },
                delegate {
                    Console.WriteLine("Success!");
                    line = reader.ReadLine();
                    character = line[30];
                },
                null,
                new Case(typeof(NullReferenceException), error => {
                    Console.WriteLine("Something was null and should not have been.");
                    Console.WriteLine("The line variable could not cause this error.");
                }),
                new Case(typeof(System.IO.FileNotFoundException), error => {
                    Console.WriteLine("File could not be found:");
                    Console.WriteLine(path);
                }),
                new Case(typeof(Exception), error => {
                    Console.WriteLine("There was an error:");
                    Console.WriteLine(error);
                }));
            return character;
        }
        public static void TryElse(Action pyTry, Action pyElse, Action pyFinally, params Case[] pyExcept) {
            if (pyElse != null && pyExcept.Length < 1) {
                throw new ArgumentException(@"there must be exception handlers if else is specified", nameof(pyExcept));
            }
            var doElse = false;
            var savedError = default(Exception);
            try {
                try {
                    pyTry();
                    doElse = true;
                } catch (Exception error) {
                    savedError = error;
                    foreach (var handler in pyExcept) {
                        if (handler.IsMatch(error)) {
                            handler.Process(error);
                            savedError = null;
                            break;
                        }
                    }
                }
                if (doElse) {
                    pyElse();
                }
            } catch (Exception error) {
                savedError = error;
            }
            pyFinally?.Invoke();
            if (savedError != null) {
                throw savedError;
            }
        }
    }
    public class Case {
        private Type ExceptionType { get; }
        public Action<Exception> Process { get; }
        private Func<Exception, bool> When { get; }
        public Case(Type exceptionType, Action<Exception> handler, Func<Exception, bool> when = null) {
            if (!typeof(Exception).IsAssignableFrom(exceptionType)) {
                throw new ArgumentException(@"exceptionType must be a type of exception", nameof(exceptionType));
            }
            this.ExceptionType = exceptionType;
            this.Process = handler;
            this.When = when;
        }
        public bool IsMatch(Exception error) {
            return this.ExceptionType.IsInstanceOfType(error) && (this.When?.Invoke(error) ?? true);
        }
    }
