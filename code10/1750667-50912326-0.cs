    for (int i = 0; i < tasks.Length; i++) {
        int iCopy = i;
        tasks[i] = Task.Run(() => {
            int iterations = 20;
            // run code that continuously enters the critical region
            for (int j = 0; j < iterations; j++) {
                WriteConsole(m, iCopy);
            }
        });
    }
