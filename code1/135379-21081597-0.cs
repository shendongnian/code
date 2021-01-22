    public class MyClass 
    {
        ...
        class Helper
        {
            static Regex re = new Regex("\\(copy (\\d+)\\)$");
            string caller;
            internal Helper([CallerMemberName] string caller = null)
            {
                this.caller = caller;
            }
            internal Regex Re
            {
                //can avoid hard coding
                get
                {
                    return caller == "AppendCopyToFileName" ? re : null;
                }
                set
                {
                    if (caller == "AppendCopyToFileName")
                        re = value;
                }
            }
        }
    
    
        private static string AppendCopyToFileName(string f)
        {
            var re = new Helper().Re; //get
            new Helper().Re = ...; //set
        }
        private static void Foo() 
        {
            var re = new Helper().Re; //gets null
            new Helper().Re = ...; //set makes no difference
        }
    }
