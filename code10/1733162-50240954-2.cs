    class Generated2
    {
        public int innerI;
    }
    for (int i = 0; i < length - 1; i++)
    {
        var context = new Generated2(); // New copy of innerI for every loop iteration
        context.innerI = i;
        taskList.Add(tf.StartNew(() => results[context.innerI] = context.innerI));
    }
