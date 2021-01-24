    IDictionary<string, int> dict = new Dictionary<string, int>(); // where you would store all
                                                                   // the answers
    
    String prompt1 = "Enter a number ...";
    String prompt2 = "Enter number of IPv4 ..."; // and so on
    // initialize your stack
    Stack<string> prompts= new Stack<string>();
    prompts.Push(prompt1);
    prompts.Push(prompt2);
    
    while(prompts.Count != 0){
        String prompt = prompts.Peek(); // this doesn't remove the element from stack
        int input = 0;
        //display prompt to user and get input in input variable
        if(input>0){ // or whatever validation logic you want
            dict.Add(prompt, input);
            prompts.Pop(); //removes topmost element
        }
    }
