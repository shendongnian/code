        [Test]
        public void FormatTemplate_GivenANamedGuid_FormattedWithB_ShouldFormatCorrectly()
        {
            // Arrange
            var template = "My guid {MyGuid:B} is awesome!";
            var templateValues = new Dictionary<string, object> { { "MyGuid", new Guid("{A4D2A7F1-421C-4A1D-9CB2-9C2E70B05E19}") } };
            var sut = new StringTemplateFormatter();
            // Act
            var result = sut.FormatTemplate(template, templateValues);
            //Assert
            Assert.That(result, Is.EqualTo("My guid {a4d2a7f1-421c-4a1d-9cb2-9c2e70b05e19} is awesome!"));
        }
