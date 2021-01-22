    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using System.Text.RegularExpressions;
    
    namespace SO.NumberExtractor.Test
    {
        public class NumberExtracter
        {
            public List<string> ExtractNumbers(string lines)
            {
                List<string> numbers = new List<string>();
                string[] seperator = { System.Environment.NewLine };
                string[] seperatedLines = lines.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                
                foreach (string line in seperatedLines)
                {
                    string s = ExtractNumber(line);
                    numbers.Add(s);
                }
    
                return numbers;
            }
    
            public string ExtractNumber(string line)
            {
                string s = line.Split(',').Last<string>().Trim('"');
                return s;
            }
    
            public string ExtractNumberWithoutLinq(string line)
            {
                string[] fields = line.Split(',');
                string s = fields[fields.Length - 1];
                s = s.Trim('"');
    
                return s;
            }
        }
    
        [TestFixture]
        public class NumberExtracterTest
        {
            private readonly string LINE1 = "AT+CMGL=\"ALL\" +CMGL: 5566,\"REC READ\",\"Ufone\" Dear customer, your DAY_BUCKET subscription will expire on 02/05/09 +CMGL: 5565,\"REC READ\",\"+923466666666\"";
            private readonly string LINE2 = "AT+CMGL=\"ALL\" +CMGL: 5566,\"REC READ\",\"Ufone\" Dear customer, your DAY_BUCKET subscription will expire on 02/05/09 +CMGL: 5565,\"REC READ\",\"+923466666667\"";
            private readonly string LINE3 = "AT+CMGL=\"ALL\" +CMGL: 5566,\"REC READ\",\"Ufone\" Dear customer, your DAY_BUCKET subscription will expire on 02/05/09 +CMGL: 5565,\"REC READ\",\"+923466666668\"";
    
            [Test]
            public void ExtractOneLineWithoutLinq()
            {            
                string expected = "+923466666666";
    
                NumberExtracter c = new NumberExtracter();
                string result = c.ExtractNumberWithoutLinq(LINE1);
    
                Assert.AreEqual(expected, result);            
            }
    
            [Test]
            public void ExtractOneLineUsingLinq()
            {
                string expected = "+923466666666";
    
                NumberExtracter c = new NumberExtracter();
                string result = c.ExtractNumber(LINE1);
    
                Assert.AreEqual(expected, result);
            }
    
            [Test]
            public void ExtractMultipleLines()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(LINE1);
                sb.AppendLine(LINE2);
                sb.AppendLine(LINE3);
    
                NumberExtracter ne = new NumberExtracter();
                List<string> extractedNumbers = ne.ExtractNumbers(sb.ToString());
    
                string expectedFirst = "+923466666666";
                string expectedSecond = "+923466666667";
                string expectedThird = "+923466666668";
    
                Assert.AreEqual(expectedFirst, extractedNumbers[0]);
                Assert.AreEqual(expectedSecond, extractedNumbers[1]);
                Assert.AreEqual(expectedThird, extractedNumbers[2]);
            }
        } 
    }
