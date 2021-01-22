    using System;
    
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    
    namespace XPathInCE
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			try
    			{
    				if (args.Length != 2)
    				{
    					ShowUsage();
    				}
    				else
    				{
    					Extract(args[0], args[1]);
    				}
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine("{0} was thrown", ex.GetType());
    				Console.WriteLine(ex.Message);
    				Console.WriteLine(ex.StackTrace);
    			}
    
    			Console.WriteLine("Press ENTER to exit");
    			Console.ReadLine();
    		}
    
    		private static void Extract(string filePath, string queryString)
    		{
    			if (!File.Exists(filePath))
    			{
    				Console.WriteLine("File not found! Path: {0}", filePath);
    				return;
    			}
    
    			XmlReaderSettings settings = new XmlReaderSettings { IgnoreComments = true, IgnoreWhitespace = true };
    			using (XmlReader reader = XmlReader.Create(filePath, settings))
    			{
    				XPathQuery query = new XPathQuery(queryString);
    				query.Find(reader);
    			}
    		}
    
    		static void ShowUsage()
    		{
    			Console.WriteLine("No file specified or incorrect number of parameters");
    			Console.WriteLine("Args must be: Filename XPath");
    			Console.WriteLine();
    			Console.WriteLine("Sample usage:");
    			Console.WriteLine("XPathInCE someXmlFile.xml ConfigurationRelease/Profiles/Profile[Name='MyProfileName']/Screens/Screen[Id='MyScreenId']/Settings/Setting[Name='MySettingName']");
    		}
    
    		class XPathQuery
    		{
    			private readonly LinkedList<ElementOfInterest> list = new LinkedList<ElementOfInterest>();
    			private LinkedListNode<ElementOfInterest> currentNode;
    
    			internal XPathQuery(string query)
    			{
    				Parse(query);
    				currentNode = list.First;
    			}
    
    			internal void Find(XmlReader reader)
    			{
    				bool skip = false;
    				while (true)
    				{
    					if (skip)
    					{
    						reader.Skip();
    						skip = false;
    					}
    					else
    					{
    						if (!reader.Read())
    						{
    							break;
    						}
    					}
    					if (reader.NodeType == XmlNodeType.EndElement
    							&& String.Compare(reader.Name, currentNode.Previous.Value.ElementName, StringComparison.CurrentCultureIgnoreCase) == 0)
    					{
    						currentNode = currentNode.Previous ?? currentNode;
    						continue;
    					}
    					if (reader.NodeType == XmlNodeType.Element)
    					{
    						string currentElementName = reader.Name;
    						Console.WriteLine("Considering element: {0}", reader.Name);
    
    						if (String.Compare(reader.Name, currentNode.Value.ElementName, StringComparison.CurrentCultureIgnoreCase) != 0)
    						{
    							// don't want
    							Console.WriteLine("Skipping");
    							skip = true;
    							continue;
    						}
    						if (!FindAttributes(reader))
    						{
    							// don't want
    							Console.WriteLine("Skipping");
    							skip = true;
    							continue;
    						}
    
    						// is there more?
    						if (currentNode.Next != null)
    						{
    							currentNode = currentNode.Next;
    							continue;
    						}
    
    						// we're at the end, this is a match! :D
    						Console.WriteLine("XPath match found!");
    						Output(reader, currentElementName);
    					}
    				}
    			}
    
    			private bool FindAttributes(XmlReader reader)
    			{
    				foreach (AttributeOfInterest attributeOfInterest in currentNode.Value.Attributes)
    				{
    					if (String.Compare(reader.GetAttribute(attributeOfInterest.Name), attributeOfInterest.Value,
    									   StringComparison.CurrentCultureIgnoreCase) != 0)
    					{
    						return false;
    					}
    				}
    				return true;
    			}
    
    			private static void Output(XmlReader reader, string name)
    			{
    				while (reader.Read())
    				{
    					// break condition
    					if (reader.NodeType == XmlNodeType.EndElement
    						&& String.Compare(reader.Name, name, StringComparison.CurrentCultureIgnoreCase) == 0)
    					{
    						return;
    					}
    
    					if (reader.NodeType == XmlNodeType.Element)
    					{
    						Console.WriteLine("Element {0}", reader.Name);
    						Console.WriteLine("Attributes");
    						for (int i = 0; i < reader.AttributeCount; i++)
    						{
    							reader.MoveToAttribute(i);
    							Console.WriteLine("Attribute: {0} Value: {1}", reader.Name, reader.Value);
    						}
    					}
    
    					if (reader.NodeType == XmlNodeType.Text)
    					{
    						Console.WriteLine("Element value: {0}", reader.Value);
    					}
    				}
    			}
    
    			private void Parse(string query)
    			{
    				IList<string> elements = query.Split('/');
    				foreach (string element in elements)
    				{
    					ElementOfInterest interestingElement = null;
    					string elementName = element;
    					int attributeQueryStartIndex = element.IndexOf('[');
    					if (attributeQueryStartIndex != -1)
    					{
    						int attributeQueryEndIndex = element.IndexOf(']');
    						if (attributeQueryEndIndex == -1)
    						{
    							throw new ArgumentException(String.Format("Argument: {0} has a [ without a corresponding ]", query));
    						}
    						elementName = elementName.Substring(0, attributeQueryStartIndex);
    						string attributeQuery = element.Substring(attributeQueryStartIndex + 1,
    									(attributeQueryEndIndex - attributeQueryStartIndex) - 2);
    						string[] keyValPair = attributeQuery.Split('=');
    						if (keyValPair.Length != 2)
    						{
    							throw new ArgumentException(String.Format("Argument: {0} has an attribute query that either has too many or insufficient = marks. We currently only support one", query));
    						}
    						interestingElement = new ElementOfInterest(elementName);
    						interestingElement.Add(new AttributeOfInterest(keyValPair[0].Trim().Replace("'", ""),
    							keyValPair[1].Trim().Replace("'", "")));
    					}
    					else
    					{
    						interestingElement = new ElementOfInterest(elementName);
    					}
    
    					list.AddLast(interestingElement);
    				}
    			}
    
    			class ElementOfInterest
    			{
    				private readonly string elementName;
    				private readonly List<AttributeOfInterest> attributes = new List<AttributeOfInterest>();
    
    				public ElementOfInterest(string elementName)
    				{
    					this.elementName = elementName;
    				}
    
    				public string ElementName
    				{
    					get { return elementName; }
    				}
    
    				public List<AttributeOfInterest> Attributes
    				{
    					get { return attributes; }
    				}
    
    				public void Add(AttributeOfInterest attribute)
    				{
    					Attributes.Add(attribute);
    				}
    			}
    
    			class AttributeOfInterest
    			{
    				private readonly string name;
    				private readonly string value;
    
    				public AttributeOfInterest(string name, string value)
    				{
    					this.name = name;
    					this.value = value;
    				}
    
    				public string Value
    				{
    					get { return value; }
    				}
    
    				public string Name
    				{
    					get { return name; }
    				}
    			}
    		}
    	}
    }
