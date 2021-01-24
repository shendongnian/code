    public class GenericTests
    {
        [Test]
        public void TestMethod1()
        {
            IFile newFile = GetNewFile("Document");
            newFile.AppendName();
            Assert.AreEqual("AppendedDocument", newFile.Name);
        }
        public IFile GetNewFile(string name)
        {
            Mock<LocalFile> file = new Mock<LocalFile>();
            file.CallBase = true;
            file.Object.AppendName();
            // remember expected result before setting up the mock
            var appendDoc = file.Object.Name;
            file.Setup(f => f.Name).Returns(name);
            file.Setup(f => f.Path).Returns(@"C:\Folder\" + name);
            file.Setup(f => f.AppendName())
                // change property behavior after call of AppendName 
                .Callback(() => file.Setup(f => f.Name).Returns(appendDoc));
            return file.Object;
        }
    }
    public interface IFile
    {
        string Name { get; set; }
        string Path { get; set; }
        void AppendName();
    }
    public class LocalFile : IFile
    {
        public virtual string Name { get; set; }
        public virtual string Path { get; set; }
        public virtual void AppendName()
        {
            this.Name = "AppendedDocument";
        }
    }
