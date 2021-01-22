    [TestFixture]
    public class ImageGalleryFixture : ContainerWiredFixture
    {
        [Test]
        public void Should_save_image()
        {
            container.ConfigureMockFor<IFileRepository>()
                .Setup(r => r.Create(It.IsAny<IFile>()))
                .Verifiable();
    
            AddToGallery(new RequestWithRealFile());
    
            container.VerifyMockFor<IFileRepository>();
        }
    
        private void AddToGallery(AddBusinessImage request)
        {
            container.Resolve<BusinessPublisher>().Consume(request);
        }
    }
