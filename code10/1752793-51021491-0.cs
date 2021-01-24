        [CustomAssertion]
        public static void BeApproximately(this NullableNumericAssertions<decimal> value, decimal? expected, decimal precision, string because = "",
            params object[] becauseArgs)
        {
            if (expected == null)
                value.BeNull(because);
            else
            {
                if (!Execute.Assertion.ForCondition(value.Subject != null).BecauseOf(because)
                    .FailWith($"Expected {{context:subject}} to be '{expected}' {{reason}} but found null"))
                    return;
                
                Decimal num = Math.Abs(expected.Value - (Decimal) value.Subject);
                Execute.Assertion.ForCondition(num <= precision).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to approximate {1} +/- {2}{reason}, but {0} differed by {3}.", (object) value.Subject, (object) expected.Value, (object) precision, (object) num);
            }
        }
