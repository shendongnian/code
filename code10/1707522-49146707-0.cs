    // declare a delegate, or use Action<string[]>
    public delegate void MethodToCall (string[] input);
    
    public class InputDialogue 
    {     
        // the public here is questionable, esp for a delegate
        public MethodToCall doThisWithTheData;  
        public InputField[] fields;
    
        public static void Query(string title, string[] fields, MethodToCall m)
        {
            // display the dialogue, allowing the user to input data into the fields
            doThisWithTheData = m;
        }
        ....
    }
