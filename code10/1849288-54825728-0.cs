    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication100
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Testrun testrun = new Testrun();
                testrun.ParseXml(FILENAME);
            }
        }
        public class Testrun
        {
            public string Commandline { get; set; }
            public Testsuite Testsuite { get; set; }
            public void ParseXml(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement Testrun = doc.Root;
                Commandline = (string)Testrun.Element("command-line");
                XElement testsuit = Testrun.Element("test-suite");
                if (testsuit != null)
                {
                    Testsuite = new Testsuite(testsuit);
                }
            }
         }
        public class Testsuite
        {
            public Attributes attributes { get; set; }
            public Testsuite testsuite { get; set; }
            public string failure_message { get; set; }
            public string property_name { get; set; }
            public string property_value { get; set; }
            public TestCase TestCase { get; set; }
            public Testsuite(XElement xTestsuite)
            {
                attributes = new Attributes(xTestsuite);
                XElement failure = xTestsuite.Element("failure");
                if (failure != null) failure_message = (string)failure.Element("message");
                XElement properties = xTestsuite.Element("properties");
                if (properties != null)
                {
                    XElement property = properties.Element("property");
                    property_name = (string)property.Attribute("name");
                    property_value = (string)property.Attribute("value");
                }
                XElement testcase = xTestsuite.Element("test-case");
                if (testcase != null)
                {
                    TestCase = new TestCase(testcase);
                }
                xTestsuite = xTestsuite.Element("test-suite");
                if (xTestsuite != null)
                {
                    testsuite = new Testsuite(xTestsuite);
                }
            }
        }
        public class TestCase
        {
            public string output { get; set; }
            public string property_name { get; set; }
            public string property_value { get; set; }
            public string attachment_filePath { get; set; }
            public string attachment_description { get; set; }
            public TestCase(XElement testCase)
            {
                XElement xOutput = testCase.Element("output");
                if (xOutput != null) output = (string)xOutput;
                XElement properties = testCase.Element("properties");
                if (properties != null)
                {
                    XElement property = properties.Element("property");
                    property_name = (string)property.Attribute("name");
                    property_value = (string)property.Attribute("value");
                }
                XElement attachments = testCase.Element("attachments");
                if (attachments != null)
                {
                    XElement attachment = attachments.Element("attachment");
                    attachment_filePath = (string)attachment.Element("filePath");
                    attachment_description = (string)attachment.Element ("description");
                }
            }
        }
        public class Attributes
        {
            string testtype { get; set; }
            string id { get; set; }
            string name { get; set; }
            string fullname { get; set; }
            string runstate  { get; set; }
            int testcasecount  { get; set; }
            string result  { get; set; }
            string site  { get; set; }
            DateTime start_time  { get; set; }
            DateTime end_time  { get; set; }
            decimal duration  { get; set; }
            int total  { get; set; }
            int passed  { get; set; }
            int failed  { get; set; }
            int warnings  { get; set; }
            int inconclusive  { get; set; }
            int skipped  { get; set; }
            int asserts { get; set; }
            public Attributes(XElement attributes)
            {
                testtype = (string)attributes.Attribute("type");
                id = (string)attributes.Attribute("id");
                name = (string)attributes.Attribute("name");
                fullname  = (string)attributes.Attribute("fullname");
                runstate  = (string)attributes.Attribute("runstate");
                testcasecount  = (int)attributes.Attribute("testcasecount");
                result = (string)attributes.Attribute("result");
                site = (string)attributes.Attribute("site");
                start_time = (DateTime)attributes.Attribute("start-time");
                end_time = (DateTime)attributes.Attribute("end-time");
                duration = (decimal)attributes.Attribute("duration");
                total = (int)attributes.Attribute("total");
                passed = (int)attributes.Attribute("passed");
                failed = (int)attributes.Attribute("failed");
                warnings = (int)attributes.Attribute("warnings");
                inconclusive = (int)attributes.Attribute("inconclusive");
                skipped = (int)attributes.Attribute("skipped");
                asserts = (int)attributes.Attribute("asserts");
            }
        }
    }
