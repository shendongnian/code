    void Foo(string[] addresses)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < addresses.Length; i++)
        {
            sb.Append(addresses[i]);
            if ((i + 1) % 50 == 0 || i == addresses.Length - 1)
            {
                Send(sb.ToString());
                sb = new StringBuilder();
            }
            else
            {
                sb.Append("; ");
            }
        }
    }
    void Send(string addresses)
    {
    }
