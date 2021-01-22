            // Modify a culture so that it has different decimal separators and group separators for numbers and percentages.
            var customCulture = new CultureInfo("en-US")
                {
                    NumberFormat = { PercentDecimalSeparator = "PDS", NumberDecimalSeparator = "NDS", PercentGroupSeparator = "PGS", NumberGroupSeparator = "NGS", PercentSymbol = "PS"}
                };
            // Set the current thread's culture to our custom culture
            Thread.CurrentThread.CurrentCulture = customCulture;
            // Create a percentage format string from a decimal value
            var percentStringCustomCulture = 123.45m.ToString("p");
            Console.WriteLine(percentStringCustomCulture); // renders "12PGS345PDS00 PS"
            // Now just replace the percent symbol only, and try to parse as a numeric value (as suggested in the other answers)
            var deceptiveNumericStringInCustomCulture = percentStringCustomCulture.Replace(customCulture.NumberFormat.PercentSymbol, string.Empty);
            // THE FOLLOWING LINE THROWS A FORMATEXCEPTION
            var decimalParsedFromDeceptiveNumericStringInCustomCulture = decimal.Parse(deceptiveNumericStringInCustomCulture); 
            // A better solution...replace the decimal separators and number group separators as well.
            var betterNumericStringInCustomCulture = deceptiveNumericStringInCustomCulture.Replace(customCulture.NumberFormat.PercentDecimalSeparator, customCulture.NumberFormat.NumberDecimalSeparator);
            // Here we mitigates issues potentially caused by group sizes by replacing the group separator by the empty string
            betterNumericStringInCustomCulture = betterNumericStringInCustomCulture.Replace(customCulture.NumberFormat.PercentGroupSeparator, string.Empty); 
            // The following parse then yields the correct result
            var decimalParsedFromBetterNumericStringInCustomCulture = decimal.Parse(betterNumericStringInCustomCulture)/100m;
