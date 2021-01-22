    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication3
    {
        delegate String xmltestFunc(String data);
    
        class Program
        {
            static readonly int iterations = 1000000;
    
            private static void benchmark(xmltestFunc func, String data, String expectedResult)
            {
                if (!func(data).Equals(expectedResult))
                {
                    Console.WriteLine(data + ": fail");
                    return;
                }
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < iterations; ++i)
                    func(data);
                sw.Stop();
                Console.WriteLine(data + ": " + (float)((float)sw.ElapsedMilliseconds / 1000));
            }
    
            static void Main(string[] args)
            {
                benchmark(xmltest1, "<tag>base</tag>", "base");
                benchmark(xmltest1, " <tag>base</tag> ", "base");
                benchmark(xmltest1, "base", "base");
                benchmark(xmltest2, "<tag>ColinBurnett</tag>", "ColinBurnett");
                benchmark(xmltest2, " <tag>ColinBurnett</tag> ", "ColinBurnett");
                benchmark(xmltest2, "ColinBurnett", "ColinBurnett");
                benchmark(xmltest3, "<tag>Si</tag>", "Si");
                benchmark(xmltest3, " <tag>Si</tag> ", "Si" );
                benchmark(xmltest3, "Si", "Si");
                benchmark(xmltest4, "<tag>RashmiPandit</tag>", "RashmiPandit");
                benchmark(xmltest4, " <tag>RashmiPandit</tag> ", "RashmiPandit");
                benchmark(xmltest4, "RashmiPandit", "RashmiPandit");
                benchmark(xmltest5, "<tag>Custom</tag>", "Custom");
                benchmark(xmltest5, " <tag>Custom</tag> ", "Custom");
                benchmark(xmltest5, "Custom", "Custom");
    
                // "press any key to continue"
                Console.WriteLine("Done.");
                Console.ReadLine();
            }
    
            public static String xmltest1(String data)
            {
                try
                {
                    return XElement.Parse(data).Value;
                }
                catch (System.Xml.XmlException)
                {
                    return data;
                }
            }
    
            static Regex xmltest2regex = new Regex("^[ \t\r\n]*<");
            public static String xmltest2(String data)
            {
                // Has to have length to be XML
                if (!string.IsNullOrEmpty(data))
                {
                    // If it starts with a < then it probably is XML
                    // But also cover the case where there is indeterminate whitespace before the <
                    if (data[0] == '<' || xmltest2regex.Match(data).Success)
                    {
                        try
                        {
                            return XElement.Parse(data).Value;
                        }
                        catch (System.Xml.XmlException)
                        {
                            return data;
                        }
                    }
                }
               return data;
            }
    
            static Regex xmltest3regex = new Regex(@"<(?<tag>\w*)>(?<text>.*)</\k<tag>>");
            public static String xmltest3(String data)
            {
                Match m = xmltest3regex.Match(data);
                if (m.Success)
                {
                    GroupCollection gc = m.Groups;
                    if (gc.Count > 0)
                    {
                        return gc["text"].Value;
                    }
                }
                return data;
            }
    
            public static String xmltest4(String data)
            {
                String result;
                if (!XmlExpresssion.TryParse(data, out result))
                    result = data;
    
                return result;
            }
    
            static Regex xmltest5regex = new Regex("^[ \t\r\n]*<");
            public static String xmltest5(String data)
            {
                // Has to have length to be XML
                if (!string.IsNullOrEmpty(data))
                {
                    // If it starts with a < then it probably is XML
                    // But also cover the case where there is indeterminate whitespace before the <
                    if (data[0] == '<' || data.Trim()[0] == '<' || xmltest5regex.Match(data).Success)
                    {
                        try
                        {
                            return XElement.Parse(data).Value;
                        }
                        catch (System.Xml.XmlException)
                        {
                            return data;
                        }
                    }
                }
                return data;
            }
        }
    
        public class XmlExpresssion
        {
            // EXPLANATION OF EXPRESSION
            // <        :   \<{1}
            // text     :   (?<xmlTag>\w+)  : xmlTag is a backreference so that the start and end tags match
            // >        :   >{1}
            // xml data :   (?<data>.*)     : data is a backreference used for the regex to return the element data      
            // </       :   <{1}/{1}
            // text     :   \k<xmlTag>
            // >        :   >{1}
            // (\w|\W)* :   Matches attributes if any
    
            // Sample match and pattern egs
            // Just to show how I incrementally made the patterns so that the final pattern is well-understood
            // <text>data</text>
            // @"^\<{1}(?<xmlTag>\w+)\>{1}.*\<{1}/{1}\k<xmlTag>\>{1}$";
    
            //<text />
            // @"^\<{1}(?<xmlTag>\w+)\s*/{1}\>{1}$";
    
            //<text>data</text> or <text />
            // @"^\<{1}(?<xmlTag>\w+)((\>{1}.*\<{1}/{1}\k<xmlTag>)|(\s*/{1}))\>{1}$";
    
            //<text>data</text> or <text /> or <text attr='2'>xml data</text> or <text attr='2' attr2 >data</text>
            // @"^\<{1}(?<xmlTag>\w+)(((\w|\W)*\>{1}(?<data>.*)\<{1}/{1}\k<xmlTag>)|(\s*/{1}))\>{1}$";
    
            private static string XML_PATTERN = @"^\<{1}(?<xmlTag>\w+)(((\w|\W)*\>{1}(?<data>.*)\<{1}/{1}\k<xmlTag>)|(\s*/{1}))\>{1}$";
            private static Regex regex = new Regex(XML_PATTERN, RegexOptions.Compiled);
    
            // Checks if the string is in xml format
            private static bool IsXml(string value)
            {
                return regex.IsMatch(value);
            }
    
            /// <summary>
            /// Assigns the element value to result if the string is xml
            /// </summary>
            /// <returns>true if success, false otherwise</returns>
            public static bool TryParse(string s, out string result)
            {
                if (XmlExpresssion.IsXml(s))
                {
                    result = regex.Match(s).Result("${data}");
                    return true;
                }
                else
                {
                    result = null;
                    return false;
                }
            }
    
        }
    
    
    }
