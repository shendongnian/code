        static void Main(string[] args)
        {
            string x = "I'm just a poor variable.  Nobody loves me.";
            Stickler.IOnlyTakeArrays_Rawr111(x); // won't go in!  square peg, round hole, etc.
            // *sigh* fine.
            Stickler.IOnlyTakeArrays_Rawr111(new[] { x });
        }
        class Stickler
        {
            public static void IOnlyTakeArrays_Rawr111(string[] yum)
            {
                // ...
            }
        }
