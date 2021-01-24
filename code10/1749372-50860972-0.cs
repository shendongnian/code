        private List<Task> _tasks = new List<Task>();
        public async Task ProcessVariable(int variable)
        {
            BaseClass c = null;
            switch(variable)
            {
                case 1:
                    c = new ClassA(variable);
                    _tasks.Add(new Task(async () => await OnAnyClass(c)));
                    _tasks.Add(new Task(async () => await OnClassA(c as ClassA, "foo")));
                    break;
                case 2:
                    //...
                    throw new NotImplementedException();
            }
            foreach(var task in _tasks)
            {
                await task;
            }
        }
