    using System;
    using NUnit.Framework;
    using NUnit.Framework.Extensions;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework.SyntaxHelpers;
    
    namespace StringChallengeProject
    {
        [TestFixture]
        public class StringChallenge
        {
            [RowTest]
            [Row(new String[] { }, "{}")]
            [Row(new[] { "ABC" }, "{ABC}")]
            [Row(new[] { "ABC", "DEF" }, "{ABC and DEF}")]
            [Row(new[] { "ABC", "DEF", "G", "H" }, "{ABC, DEF, G and H}")]
            public void Test(String[] input, String expectedOutput)
            {
                Assert.That(FormatString(input), Is.EqualTo(expectedOutput));
            }
            //codesnippet:93458590-3182-11de-8c30-0800200c9a66
            public static String FormatString(IEnumerable<String> input)
            {
                if (input == null)
                    return "{}";
    
                using (var iterator = input.GetEnumerator())
                {
                    // Guard-clause for empty source
                    if (!iterator.MoveNext())
                        return "{}";
    
                    // Take care of first value
                    var output = new StringBuilder();
                    output.Append('{').Append(iterator.Current);
    
                    // Grab next
                    if (iterator.MoveNext())
                    {
                        // Grab the next value, but don't process it
                        // we don't know whether to use comma or "and"
                        // until we've grabbed the next after it as well
                        String nextValue = iterator.Current;
                        while (iterator.MoveNext())
                        {
                            output.Append(", ");
                            output.Append(nextValue);
    
                            nextValue = iterator.Current;
                        }
    
                        output.Append(" and ");
                        output.Append(nextValue);
                    }
    
    
                    output.Append('}');
                    return output.ToString();
                }
            }
        }
    }
