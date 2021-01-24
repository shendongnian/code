    public class NUnitTest
    {
        [TestFixture]
        public class UnitTest1
        {
            private Mock<Sample> _sample;
            private FileInfo _fileInfo;
            [SetUp]
            public void Setup()
            {
                _sample = new Mock<Sample>();
                
            }
    
            [Test]
            public void File_Should_Not_Delete()
            {
                _fileInfo = new FileInfo("file");
                _fileInfo.Create();
    
                _sample.Setup(x => x.GetFiles(It.IsAny<string>())).Returns(() => new[] {"file1"});
                _sample.Setup(x => x.GetFileInfo(It.IsAny<string>())).Returns(() => _fileInfo);
                _sample.Setup(x => x.DeleteFile(It.IsAny<FileInfo>())).Verifiable();
                _sample.Object.Delete("file1",2);
    
                _sample.Verify(x => x.DeleteFile(It.IsAny<FileInfo>()), Times.Never);
    
            }
    
            [Test]
            public void File_Should_Delete()
            {
                _fileInfo = new FileInfo("file1");
                _fileInfo.Create();
    
                _sample.Setup(x => x.GetFiles(It.IsAny<string>())).Returns(() => new[] { "file1" });
                _sample.Setup(x => x.GetFileInfo(It.IsAny<string>())).Returns(() => _fileInfo);
                _sample.Setup(x => x.DeleteFile(It.IsAny<FileInfo>())).Verifiable();
                _sample.Object.Delete("file1", -2);
                
                _sample.Verify(x => x.DeleteFile(It.IsAny<FileInfo>()), Times.Once);
    
            }
        }
    }
