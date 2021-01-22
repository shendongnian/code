    public enum CardType
    {
        MasterCard,
        Visa,
        AmericanExpress,
    }
    public static class CardValidator
    {
        public static bool Validate(CardType cardType, string cardNumber)
        {
            string strippedCardNumber = Regex.Replace(cardNumber, @"\D", String.Empty);
            ICardValidator validator = SelectCardValidator(cardType);
            return validator.Validate(strippedCardNumber);
        }
        private static ICardValidator SelectCardValidator(CardType cardType)
        {
            switch (cardType)
            {
                case CardType.MasterCard:
                    return new MasterCardValidator();
                case CardType.Visa:
                    return new VisaValidator();
                case CardType.AmericanExpress:
                    return new AmericanExpressValidator();
                default:
                    return new UnknownCardTypeValidator();
            }
        }
        private interface ICardValidator
        {
            bool Validate(string cardNumber);
        }
        private class UnknownCardTypeValidator : ICardValidator
        {
            #region ICardValidator Members
            public bool Validate(string cardNumber)
            {
                return false;
            }
            #endregion
        }
        private abstract class LuhnAlgorithmValidator : ICardValidator
        {
            #region ICardValidator Members
            public virtual bool Validate(string cardNumber)
            {
                // Implement Luhn Algorithm here
                return false;
            }
            #endregion
        }
        private class MasterCardValidator : LuhnAlgorithmValidator
        {
            public override bool Validate(string cardNumber)
            {
                bool isValid = false; // replace with MasterCard validation
                return isValid && base.Validate(cardNumber);
            }
        }
        private class VisaValidator : LuhnAlgorithmValidator
        {
            public override bool Validate(string cardNumber)
            {
                bool isValid = false; // replace with Visa validation
                return isValid && base.Validate(cardNumber);
            }
        }
        private class AmericanExpressValidator : LuhnAlgorithmValidator
        {
            public override bool Validate(string cardNumber)
            {
                bool isValid = false; // replace with AmEx validation
                return isValid && base.Validate(cardNumber);
            }
        }
    }
