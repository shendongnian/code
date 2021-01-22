    /// <summary>
    /// Swaps to elements
    /// Generic implementation by LMF
    /// </summary>
    public static void Swap<T>(ref T itemLeft, ref T itemRight) {
        T dummyItem = itemRight;
        itemLeft = itemRight;
        itemRight = dummyItem;
    }
