        [Test]
        public void ShouldFailIfEmailAddressAttributeIsMissingFromFieldName()
        {
            //--Arrange
            var model = new { Field = 1 };
            //--Act
            Should.Throw<EmailAddressAttributeNotFoundException>(() => model.ShouldValidateTheseFields(
                new List<FieldValidation>
                {
                    new EmailAddressFieldValidation
                    {
                        ErrorId = 1,
                        ErrorMessage = "Message",
                        FieldName = nameof(model.Field)
                    }
                }));
        }
