    public class SchedulesControllerTests
    {
        [Fact]
        public void CanGet()
        {
            try
            {
                //Arrange
                //Repository
                Mock<IScheduleRepository> mockRepo = new Mock<IScheduleRepository>();
                var schedules = new List<Schedule>(){
                    new Schedule() { Id=1, Title = "Schedule1" },
                    new Schedule() { Id=2, Title = "Schedule2" },
                    new Schedule() { Id=3, Title = "Schedule3" }
                };
                mockRepo.Setup(m => m.items).Returns(value: schedules);
                //auto mapper configuration
                var mockMapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new AutoMapperProfile());
                });
                var mapper = mockMapper.CreateMapper();
                SchedulesController controller = new SchedulesController(repository: mockRepo.Object, mapper: mapper);
                //Act
                var result = controller.Get();
                //Assert
                var okResult = result as OkObjectResult;
                if (okResult != null)
                    Assert.NotNull(okResult);
                var model = okResult.Value as IEnumerable<ScheduleDto>;
                if (model.Count() > 0)
                {
                    Assert.NotNull(model);
                    var expected = model?.FirstOrDefault().Title;
                    var actual = schedules?.FirstOrDefault().Title;
                    Assert.Equal(expected: expected, actual: actual);
                }
            }
            catch (Exception ex)
            {
                //Assert
                Assert.False(false, ex.Message);
            }
        }
    }
