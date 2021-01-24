            var oneSectionMock = new Mock<IConfigurationSection>();
            oneSectionMock.Setup(s => s.Value).Returns("1");
            var twoSectionMock = new Mock<IConfigurationSection>();
            twoSectionMock.Setup(s => s.Value).Returns("2");
            var fooBarSectionMock = new Mock<IConfigurationSection>();
            fooBarSectionMock.Setup(s => s.GetChildren()).Returns(new List<IConfigurationSection> { oneSectionMock.Object, twoSectionMock.Object });
            _configurationMock.Setup(c => c.GetSection("foo:bar")).Returns(fooBarSectionMock.Object);
