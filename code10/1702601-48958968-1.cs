    public class ConfigurationRepositoryTests {
        private static ConfigurationRepositoryImpl MakeRepo() {
            return new ConfigurationRepositoryImpl();
        }
        public class GetConnectionString {
            [Fact]
            public void GoodConnectionName_ReturnsExpectedValue() {
                // arrange
                var repo = MakeRepo();
                var key = "TestConnectionString";
                var expected = "Sample Connection String";
                
                // act
                ConfigurationRepositoryImpl.SetConnecitonString("TestConnectionString", "Sample Connection String");
                var test = repo.GetConnectionString(key);
                ConfigurationRepositoryImpl.ResetConnectionStrings();
                // assert
                test.Should()
                    .Be(expected);
            }
            [Fact]
            public void BadConnectionName_ThrowsNullReferenceException() {
                // arrange
                var repo = MakeRepo();
                var key = "BadKeyName";
                
                // act
                Action act = () => {
                                 repo.GetConnectionString(key);
                             };
                // assert
                act.Should()
                   .Throw<NullReferenceException>();
            }
        }
        public class GetValue {
            [Fact]
            public void GoodKey_ReturnsExpectedValue() {
                // arrange
                var repo = MakeRepo();
                var key = "TestAppSetting";
                var expected = "Sample App Setting";
                // act
                ConfigurationRepositoryImpl.SetValue("TestAppSetting", "Sample App Setting");
                var test = repo.GetValue(key, null);
                ConfigurationRepositoryImpl.ResetValues();
                // assert
                test.Should()
                    .Be(expected);
            }
            [Fact]
            public void BadKeyWithNullDefaultValue_ReturnsNull() {
                // arrange
                var repo = MakeRepo();
                var key = "BadKeyName";
                
                // act
                var test = repo.GetValue(key, null);
                // assert
                test.Should()
                    .BeNull();
            }
            [Fact]
            public void BadKeyWithGoodDefaultValue_ReturnsDefaultValue() {
                // arrange
                var repo = MakeRepo();
                var key = "BadKeyName";
                var defaultValue = "Good Value";
                var expected = "Good Value";
                // act
                var test = repo.GetValue(key, defaultValue);
                // assert
                test.Should()
                    .Be(expected);
            }
        }
    }
