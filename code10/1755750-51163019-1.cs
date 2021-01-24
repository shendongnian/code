    public void Start(Action<byte[]> bytesAction)
        {
            var imageTask = Task.Factory.StartNew(() =>
                                                      {
                                                          //var GeneratedBytes = GenerateImage();
                                                          //How to send GeneratedBytes to client?
                                                          bytesAction(GenerateImage());
                                                      });
        }
