    System.Text.StringBuilder buffer;
    buffer = new System.Text.StringBuilder();
    buffer.EnsureCapacity(21);
    QuerySoftwareVersion(buffer);
    string = buffer.ToString();
