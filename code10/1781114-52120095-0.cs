    [TestClass]
    public class MyTestClass {
        public class Preferences {
        }
        public interface IInterface {
            Task<string> Upsert(Preferences prefs, string id);
        }
        public Task<string> _upsertMock(Preferences prefs, string id) {
            return Task.Run(() => {
                return id;
            });
        }
        [Test]
        public async Task MyTestMethod() {
            var mock = new Mock<IInterface>();
            mock
                .Setup(_ => _.Upsert(It.IsAny<Preferences>(), It.IsAny<string>()))
                .Returns((Func<Preferences, string, Task<string>>)_upsertMock);
            var expected = "123";
            var actual = await mock.Object.Upsert(null, expected);
            actual.Should().Be(expected);
        }
    }
