    for(int i = 0; i < actions.Length; ++i) {
        try {
            actions[i].Invoke();
        }
        
        catch(TestFailedException) {
            if(i > 1)
                i -= 1;
        }
    }
