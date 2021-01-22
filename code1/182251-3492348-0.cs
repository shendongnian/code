               byte[] actual = new byte[255];
            // writing locally, can be done from resource manifest as well.
            using (StreamWriter writer = new StreamWriter(new MemoryStream(actual)))
            {
                writer.WriteLine("Hello world");
                writer.Flush();
            }
            
            // arrange the file system.
            FileStream fs = (FileStream)FormatterServices
                .GetSafeUninitializedObject(typeof(FileStream));
            // mocking the specific call and setting up expectations.
            Mock.Arrange(() => fs.Write(Arg.IsAny<byte[]>(), Arg.AnyInt, Arg.AnyInt))
                .DoInstead((byte[] content, int offset, int len) =>
            {
                actual.CopyTo(content, offset);
            });
            // return custom filestream for File.Open.
            Mock.Arrange(() => File.Open(Arg.AnyString, Arg.IsAny<FileMode>()))
                 .Returns(fs);
            // act
            var fileStream =  File.Open("hello.txt", FileMode.Open);
            byte[] fakeContent = new byte[actual.Length];
            // original task
            fileStream.Write(fakeContent, 0, actual.Length);
            // assert
            Assert.Equal(fakeContent.Length, actual.Length);
            for (var i = 0; i < fakeContent.Length; i++)
            {
                Assert.Equal(fakeContent[i], actual[i]);
            }
