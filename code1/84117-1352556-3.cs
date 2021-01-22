        foreach (string s in new[]
        {
            "foo",              // no quotes
            "\"foo",            // double quotes only
            "'foo",             // single quotes only
            "'foo\"bar",        // both; double quotes in mid-string
            "'foo\"bar\"baz",   // multiple double quotes in mid-string
            "'foo\"",           // string ends with double quotes
            "'foo\"\"",         // string ends with run of double quotes
            "\"'foo",           // string begins with double quotes
            "\"\"'foo",         // string begins with run of double quotes
            "'foo\"\"bar"       // run of double quotes in mid-string
        })
        {
            Console.Write(s);
            Console.Write(" = ");
            Console.WriteLine(XPathLiteral(s));
            XmlElement elm = d.CreateElement("test");
            d.DocumentElement.AppendChild(elm);
            elm.SetAttribute("value", s);
            string xpath = "/root/test[@value = " + XPathLiteral(s) + "]";
            if (d.SelectSingleNode(xpath) == elm)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Should have found a match for {0}, and didn't.", s);
            }
        }
        Console.ReadKey();
    }
