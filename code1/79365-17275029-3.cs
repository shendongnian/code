       [Test]
       public void NewSocketFactoryCreatesSocketDefaultConstructor()
            {
                webRequestFactory = new HTTPRequestFactory3();
                Assert.NotNull(webRequestFactory._socket);
                Socket testSocket = webRequestFactory._socket as Socket;
                Assert.IsInstanceOf<Socket>(testSocket);
            }
