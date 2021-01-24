    [Test]
    public void ShouldFailIfEmailAddressAttributeHasWrongErrorId()
    {
        //--Arrange
        var model = new TestModelTwo();
        //--Act
        Should.Throw<ShouldAssertException>(() => model.ShouldValidateTheseFields(
        new List<FieldValidation>
        {
            new EmailAddressFieldValidation
            {
                ErrorId = 2,
                ErrorMessage = "Message",
                FieldName = nameof(model.Field)
            }
        }));
    }
