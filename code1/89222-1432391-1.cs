    public void Reverse()
    {
        MyStack reverse = new MyStack();
        while (Initial != null)
        {
           reverse.Push(this.Pop());
        }
        Initial = reverse.Initial;
    }
