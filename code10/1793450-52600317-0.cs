    using System;
    using System.Xml.Linq;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
    	public static void Main()
    	{
    		String rxml = @"<TestMessage>
              <TestIdentification>
                <TestID>106491</TestID>
                <TestType>TESTID1</TestType>
              </TestIdentification>
              <TestIdentification>
                <TestID>106492</TestID>
                <TestType>TESTID2</TestType>
              </TestIdentification>
              <TestIdentification>
                <TestID>106493</TestID>
                <TestType>TESTID3</TestType>
              </TestIdentification>
              <TestIdentification>
                <TestID>106494</TestID>
                <TestType>TESTID4</TestType>
              </TestIdentification>
              </TestMessage>
              ";
    		XElement xml = XElement.Parse(rxml);
    		// Let Xml.Linq pick out the "TestIdentification" XElements
    		foreach (var tid in xml.Descendants("TestIdentification"))
    		{
    			TestClassObj testObj = new TestClassObj(tid.Element("TestID").Value, tid.Element("TestType").Value);
    			Console.WriteLine(testObj);
    		}
    		Console.WriteLine("Any Key to Continue...");
    		Console.ReadKey();
    	}
    }
    public class TestClassObj
    {
        // Make sure we can construct a TestClassObj on-demand
        public TestClassObj(string testID, string testText)
    	{
    		TestID = testID;
    		TestText = testText;
    	}
    	public String TestID { get; set; }
    	public String TestText { get; set; }
        // Define how we would like the object displayed
    	public override string ToString()
    	{
    		return "TestID:" + TestID + " TestText:" + TestText;
    	}
    }
