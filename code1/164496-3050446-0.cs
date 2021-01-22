    string GetPictureAt(int index)
    {
        // Copes with values which are two large or too small,
        // but only as far as -pictures.Length
        if (index < 0)
        {
            index += pictures.Length;
        }
        return pictures[index % pictures.Length];
    }
