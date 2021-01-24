        [CustomAssertion]
        public static void BeKindaCloseTo(this NumericAssertions<double> value, double expected, double tolerance, string because = "", params object[] becauseArgs)
        {
            if (!Execute.Assertion.ForCondition(value.Subject != null)
                .BecauseOf(because)
                .FailWith($"Expected {{context:subject}} to be '{expected}' {{reason}} but found null"))
                return;
            var actual = (double)value.Subject;
            var diff = Math.Abs(expected - actual);
            if (diff > double.Epsilon)
            {
                var percent = Math.Round( 100 / (expected / diff),2);
                Execute.Assertion.ForCondition(diff <= tolerance)
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected {context:value} to approximate {1} +/- {2}%{reason}, but {0} differed by {3}%.", actual, expected, tolerance, percent);
            }
        }
