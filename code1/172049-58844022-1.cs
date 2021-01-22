    public class ValidationModel
    {
        public const string InvalidScheme = "Invalid URI scheme.";
        public const string EmptyInputValue = "Empty input value.";
        public const string InvalidUriFormat = "Invalid URI format.";
        public const string PassedValidation = "Passed validation";
        public const string HttpScheme = "http://";
        public const string HttpsScheme = "https://";
        public bool IsValid { get; set; }
        public string ValidationMessage { get; set; }
        
    }
##UrlValidator.cs
    public static class UrlValidator
    {
        public static ValidationModel Validate(string input)
        {
            var validation = new ValidationModel();
            if (input == string.Empty)
            {
                validation.IsValid = false;
                validation.ValidationMessage = ValidationModel.EmptyInputValue;
                return validation;
            }
            try
            {
                var uri = new Uri(input);
                var leftPart = uri.GetLeftPart(UriPartial.Scheme);
                if (leftPart.Equals(ValidationModel.HttpScheme) || leftPart.Equals(ValidationModel.HttpsScheme))
                {
                    validation.IsValid = true;
                    validation.ValidationMessage = ValidationModel.PassedValidation;
                    return validation;
                }
                
                validation.IsValid = false;
                validation.ValidationMessage = ValidationModel.InvalidScheme;
            }
            catch (UriFormatException)
            {
                validation.IsValid = false;
                validation.ValidationMessage = ValidationModel.InvalidUriFormat;
            }
            
            return validation;
        }
    }
### UrlValidatorTests.cs
    public class UrlValidatorTests
    {
        [Theory]
        [InlineData("http://intel.com", true, ValidationModel.PassedValidation)]
        [InlineData("https://intel.com", true, ValidationModel.PassedValidation)]
        [InlineData("https://intel.com/index.html", true, ValidationModel.PassedValidation)]
        [InlineData("", false, ValidationModel.EmptyInputValue)]
        [InlineData("http://", false, ValidationModel.InvalidUriFormat)]
        [InlineData("//intel.com", false, ValidationModel.InvalidScheme)]
        [InlineData("://intel.com", false, ValidationModel.InvalidUriFormat)]
        [InlineData("f://intel.com", false, ValidationModel.InvalidScheme)]
        [InlineData("htttp://intel.com", false, ValidationModel.InvalidScheme)]
        [InlineData("intel.com", false, ValidationModel.InvalidUriFormat)]
        [InlineData("ftp://intel.com", false, ValidationModel.InvalidScheme)]
        [InlineData("http:intel.com", false, ValidationModel.InvalidUriFormat)]
        public void Validate_Input_ExpectedResult(string input, bool expectedResult, string expectedInvalidMessage)
        {
            //Act
            var result = UrlValidator.Validate(input);
            //Assert
            Assert.Equal(expectedResult, result.IsValid);
            Assert.Equal(expectedInvalidMessage, result.ValidationMessage);
        }
    }
###TEST RESULTS:
[![test results][1]][1]
  [1]: https://i.stack.imgur.com/rWEoO.png
