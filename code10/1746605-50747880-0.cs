    [Test]
    public void ShouldFailIfEmailAttributeMissingFromFieldName() {
        //--Arrange
        var model = new { Field = 1 };
        //--Act
        try {
            model.ShouldValidateTheseFields(new List<FieldValidation> {
                new EmailAddressFieldValidation {
                    ErrorId = 1,
                    ErrorMessage = "Message",
                    FieldName = nameof(model.Field)
                }
            });
        } catch(MyExpectedException e) {
            return;
        }
        //--Assert
        Assert.Fail();
    }
