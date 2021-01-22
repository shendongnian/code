    void WriterLoop() {
        SomeWorkItem item; // could be a `DataTable` or similar
        while(queue.TryDequeue(out item)) {
            // process item
        }
        // queue is empty and has been closed; all done, so exit...
    }
