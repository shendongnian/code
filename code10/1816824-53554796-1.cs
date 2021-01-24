    public Service()
    {
        client = new HttpClient();
        client.MaxResponseContentBufferSize = 256000;
    }
