    class Generated1
    {
        public int i;
    }
    var context = new Generated1(); // Exactly one copy of i
    for (context.i = 0; context.i < length - 1; context.i++)
    {
        taskList.Add(tf.StartNew(() => results[context.i] = context.i));
    }
