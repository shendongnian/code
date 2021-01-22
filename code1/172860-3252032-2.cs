public class Storage&lt;T&gt; : IDisposable, IEnumerable&lt;T&gt; where T : struct
{
    MemoryMappedFile mappedFile;
    MemoryMappedViewAccessor accesor;
    long elementSize;
    long numberOfElements;
    public Storage(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException();
        }
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException();
        }
        FileInfo info = new FileInfo(filePath);
        mappedFile = MemoryMappedFile.CreateFromFile(filePath);
        accesor = mappedFile.CreateViewAccessor(0, info.Length);
        elementSize = Marshal.SizeOf(typeof(T));
        numberOfElements = info.Length / elementSize;
    }
    public long Length
    {
        get
        {
            return numberOfElements;
        }
    }
    public T this[long index]
    {
        get
        {
            if (index &lt; 0 || index &gt; numberOfElements)
            {
                throw new ArgumentOutOfRangeException();
            }
            T value = default(T);
            accesor.Read&lt;T&gt;(index * elementSize, out value);
            return value;
        }
    }
    public void Dispose()
    {
        if (accesor != null)
        {
            accesor.Dispose();
            accesor = null;
        }
        if (mappedFile != null)
        {
            mappedFile.Dispose();
            mappedFile = null;
        }
    }
    public IEnumerator&lt;T&gt; GetEnumerator()
    {
        T value;
        for (int index = 0; index &lt; numberOfElements; index++)
        {
            value = default(T);
            accesor.Read&lt;T&gt;(index * elementSize, out value);
            yield return value;
        }
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        T value;
        for (int index = 0; index &lt; numberOfElements; index++)
        {
            value = default(T);
            accesor.Read&lt;T&gt;(index * elementSize, out value);
            yield return value;
        }
    }
    
    public static T[] GetArray(string filePath)
    {
        T[] elements;
        int elementSize;
        long numberOfElements;
                
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException();
        }
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException();
        }
        FileInfo info = new FileInfo(filePath);
        using (MemoryMappedFile mappedFile = MemoryMappedFile.CreateFromFile(filePath))
        {
            using(MemoryMappedViewAccessor accesor = mappedFile.CreateViewAccessor(0, info.Length))
            {
                elementSize = Marshal.SizeOf(typeof(T));
                numberOfElements = info.Length / elementSize;
                elements = new T[numberOfElements];
                if (numberOfElements &gt; int.MaxValue)
                {
                    //you will need to split the array
                }
                else
                {
                    accesor.ReadArray&lt;T&gt;(0, elements, 0, (int)numberOfElements);
                }
            }
        }
        return elements;
    }
}
