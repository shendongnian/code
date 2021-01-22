    // <copyright file="RomanNumeralExtensions.cs" company="Always Elucidated Solution Pioneers, LLC">
    // Copyright (c) 2008 Always Elucidated Solution Pioneers, LLC.  All Rights Reserved.
    // </copyright>
    // <author>Jesse C. Slicer</author>
    // <email>jslicer@spamcop.net</email>
    // <date>2008-10-01</date>
    // <summary>Translates Roman numeral strings to integers and vice-versa.</summary>
        
    namespace Aesop.Extensions
    {
        // System namespaces
        using System;
        using System.Collections.Generic;
        using System.Text;
        using System.Text.RegularExpressions;
    
        /// <summary>
        /// Holds the IsValidRomanNumeral(), ParseRomanNumeral() and ToRomanNumeralString() extension methods.
        /// </summary>
        public static class RomanNumeralExtensions
        {
            /// <summary>
            /// The number of mappings in the dictionary.
            /// </summary>
            private const int NumberOfRomanNumeralMaps = 13;
    
            /// <summary>
            /// The matching of Roman numeral placeholders to their integer equivalents.
            /// </summary>
            private static readonly Dictionary<string, int> romanNumerals =
                new Dictionary<string, int>(NumberOfRomanNumeralMaps)
                {
                    { "M", 1000 }, 
                    { "CM", 900 }, 
                    { "D", 500 }, 
                    { "CD", 400 }, 
                    { "C", 100 }, 
                    { "XC", 90 }, 
                    { "L", 50 }, 
                    { "XL", 40 }, 
                    { "X", 10 }, 
                    { "IX", 9 }, 
                    { "V", 5 }, 
                    { "IV", 4 }, 
                    { "I", 1 }
                };
    
            /// <summary>
            /// The regular expression to test the string against.
            /// </summary>
            private static readonly Regex validRomanNumeral = new Regex(
                "^(?i:(?=[MDCLXVI])((M{0,3})((C[DM])|(D?C{0,3}))"
                + "?((X[LC])|(L?XX{0,2})|L)?((I[VX])|(V?(II{0,2}))|V)?))$", 
                RegexOptions.Compiled);
    
            /// <summary>
            /// Determines whether the specified string is a valid Roman numeral.
            /// </summary>
            /// <param name="value">
            /// The Roman numeral string to validate.
            /// </param>
            /// <returns>
            /// <c>true</c> if the specified string is a valid Roman numeral; otherwise, <c>false</c>.
            /// </returns>
            public static bool IsValidRomanNumeral(this string value)
            {
                return validRomanNumeral.IsMatch(value);
            }
    
            /// <summary>
            /// Parses the Roman numeral into its integer equivalent.
            /// </summary>
            /// <param name="value">
            /// The Roman numeral string.
            /// </param>
            /// <returns>
            /// The integer representation of the Roman numeral.
            /// </returns>
            public static int ParseRomanNumeral(this string value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
    
                value = value.ToUpperInvariant().Trim();
    
                var length = value.Length;
    
                if ((length == 0) || !value.IsValidRomanNumeral())
                {
                    throw new ArgumentException("Empty or invalid Roman numeral string.", "value");
                }
    
                var total = 0;
                var i = length;
    
                while (i > 0)
                {
                    var digit = romanNumerals[value[--i].ToString()];
    
                    if (i > 0)
                    {
                        var previousDigit = romanNumerals[value[i - 1].ToString()];
    
                        if (previousDigit < digit)
                        {
                            digit -= previousDigit;
                            i--;
                        }
                    }
    
                    total += digit;
                }
    
                return total;
            }
    
            /// <summary>
            /// Converts the number to its equivalent Roman numeral string.
            /// </summary>
            /// <param name="value">
            /// The integer to convert.
            /// </param>
            /// <returns>
            /// The Roman numeral representation of the integer.
            /// </returns>
            public static string ToRomanNumeralString(this int value)
            {
                const int MinValue = 1;
                const int MaxValue = 3999;
    
                if ((value < MinValue) || (value > MaxValue))
                {
                    throw new ArgumentOutOfRangeException("value", value, "Argument out of Roman numeral range.");
                }
    
                const int MaxRomanNumeralLength = 15;
                var sb = new StringBuilder(MaxRomanNumeralLength);
    
                foreach (var pair in romanNumerals)
                {
                    while (value / pair.Value > 0)
                    {
                        sb.Append(pair.Key);
                        value -= pair.Value;
                    }
                }
    
                return sb.ToString();
            }
    
        }
    }
