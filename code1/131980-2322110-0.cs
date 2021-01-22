    abstract class Actor
    {
        Queue<Action> _messages = new Queue<Action>();
        protected void Submit(Action action)
        {
            // take out a lock of course
            _messages.Enqueue(action);
        }
        // also a "run" that reads and executes the 
        // message delegates on background threads
    }
