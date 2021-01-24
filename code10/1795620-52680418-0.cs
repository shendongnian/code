    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                IFormatProvider provider = CultureInfo.InvariantCulture;
                var results = doc.Descendants("MIR").Select(mir => new
                {
                    Number = (string)mir.Attribute("number"),
                    Revision = (string)mir.Attribute("revision"),
                    From = (string)mir.Element("issue_data").Element("from"),
                    Material = (string)mir.Element("issue_data").Element("material_group"),
                    Field = (string)mir.Element("issue_data").Element("field"),
                    Submittal = (string)mir.Element("issue_data").Element("related_sub"),
                    To = (string)mir.Element("issue_data").Element("to"),
                    Atten = (string)mir.Element("issue_data").Element("attn"),
                    IssueDate =   DateTime.ParseExact((string)mir.Descendants("issue_date").FirstOrDefault(), "dd-M-yyyy",provider),
                    ReplyDate = (string)mir.Descendants("receive_date").FirstOrDefault() == string.Empty ? new DateTime() : DateTime.ParseExact((string)mir.Descendants("receive_date").FirstOrDefault(), "dd-M-yyyy", provider),
                    ActionCode = (string)mir.Element("reply_data").Element("action_code"),
                    Author = (string)mir.Element("issue_data").Element("author"),
                    IsSubmitted = (string)mir.Element("submission_data").Element("submitted"),
                    Status = (string)mir.Element("submission_data").Element("status")
                }).First();
            }
        }
    }
