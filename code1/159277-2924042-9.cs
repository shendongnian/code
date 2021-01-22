    using System;
    using Xunit;
    public class DecimalExtensionsTests
    {
                             // digit positions
                             // 1234567890123456789012345678
        const decimal number = .3216879846541681986310378765m;
        [Fact]
        public void Throws_ArgumentException_if_position_is_zero()
        {
            Assert.Throws<ArgumentException>(() => number.DigitAtPosition(0));
        }
        [Fact]
        public void Throws_ArgumentException_if_position_is_negative()
        {
            Assert.Throws<ArgumentException>(() => number.DigitAtPosition(-5));
        }
        [Fact]
        public void Works_for_1st_digit()
        {
            Assert.Equal(3, number.DigitAtPosition(1));
        }
        [Fact]
        public void Works_for_28th_digit()
        {
            Assert.Equal(5, number.DigitAtPosition(28));
        }
        [Fact]
        public void Works_for_negative_decimals()
        {
            const decimal negativeNumber = -number;
            Assert.Equal(5, negativeNumber.DigitAtPosition(28));
        }
        [Fact]
        public void Returns_zero_for_whole_numbers()
        {
            const decimal wholeNumber = decimal.MaxValue;
            Assert.Equal(0, wholeNumber.DigitAtPosition(1));
        }
        [Fact]
        public void Returns_zero_if_position_is_greater_than_the_number_of_decimal_digits()
        {
            Assert.Equal(0, number.DigitAtPosition(29));
        }
        [Fact]
        public void Does_not_throw_if_number_is_max_decimal_value()
        {
            Assert.DoesNotThrow(() => decimal.MaxValue.DigitAtPosition(1));
        }
        [Fact]
        public void Does_not_throw_if_number_is_min_decimal_value()
        {
            Assert.DoesNotThrow(() => decimal.MinValue.DigitAtPosition(1));
        }
        [Fact]
        public void Does_not_throw_if_position_is_max_integer_value()
        {
            Assert.DoesNotThrow(() => number.DigitAtPosition(int.MaxValue));
        }
    }
