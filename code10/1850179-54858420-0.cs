c#
public class BlockingQueue<T>
{
    private Queue<T> _queue = new Queue<T>;
    private Semaphore _sem -= new Semaphore();
    public int Count
    {
        get
        {
            return this._queue.Count;
        }
    }
    public T Dequeue()
    {
        T t;
        this._sem.WaitOne();
        lock (this._queue)
        {
            t = this._queue.Dequeue();
        }
        return t;
    }
    public void Enqueue(T item)  // < = item have two value but when insert value to Queue<t> _queue null value return error
    {
        lock (this._queue)
        {
            this._queue.Enqueue(item);
        }
        this._sem.Release();
    }
}
