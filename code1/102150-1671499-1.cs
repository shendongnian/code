    class One
    {
        Queue<string>[] queueArray;
    
        public One(Queue<string>[] queueArray)
        {
    		if (queueArray == null) throw new ArgumentNullException("queueArray");
    		if (queueArray.Length != 1) throw new ArgumentException("queueArray must have one and only one item");
            this.queueArray = queueArray;
        }
    
        public void Produce()
        {
            queueArray[0] = new Queue<string>();
            queueArray[0].Enqueue("one");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var queueArray = new Queue<string>[] { new Queue<string>() };
    
            One one = new One(queueArray);
            one.Produce();
    
            string value = queueArray[0].Dequeue(); //this line sets "one" to value
        }
    }
