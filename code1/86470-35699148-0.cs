        string starters = "({[<";
        string enders = ")}]>";
        Stack stack  = new Stack();
        foreach(char c in txtValue.Text.Trim())
        {
            if(starters.Contains(c))
            {
                stack.Push(c);
            }
            else if (enders.Contains(c))
            {
                if (stack.Count > 0)
                {
                    if (enders.IndexOf(c) == starters.IndexOf(Convert.ToChar(stack.Peek())))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        lblResult.Text = "Invaluid string";
                    }
                }
            }
        }
        if(stack.Count == 0)
        {
            lblResult.Text = "Valid string";
        }
        else
        {
            lblResult.Text = "InValid string";
        }
