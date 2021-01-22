    private void Resize(int newCapacity)
    {
        T[] tmp = new T[newCapacity];
        Array.Copy(backingArray, tmp, backingArray.Length);
        backingArray = tmp;
    }
