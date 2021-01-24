    using System;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    
    namespace FormatXml {
        class Program {
            static String OutputElement(int indentCnt, XElement ele) {
                StringBuilder sb = new StringBuilder();
    
                var indent = "".PadLeft(indentCnt, '\t');
                var specialFormat = (ele.Parent == null) ? false : ((ele.Parent.Name == "Name") ? true : false);
                sb.Append($"{indent}<{ele.Name}");
    
                String FormatAttr(XAttribute attr) {
                    return $"{attr.Name} = '{attr.Value}'";
                    }
    
                String FormatAttrByName(String name) {
                    var attr = ele.Attributes().Where(x => x.Name == name).FirstOrDefault();
                    var rv = "";
                    if (attr == null) {
                        rv = $"{name}=''";
                        }
                    else {
                        rv = FormatAttr(attr);
                        }
                    return rv;
                    }
    
                if (specialFormat) {
                    var dob       = FormatAttrByName("DOB");
                    var firstName = FormatAttrByName("FirstName");
                    var lastName  = FormatAttrByName("LastName");
                    var address   = FormatAttrByName("Address");
                    var phoneNum  = FormatAttrByName("PhoneNum");
                    var city      = FormatAttrByName("City");
                    var state     = FormatAttrByName("State");
                    var country   = FormatAttrByName("Country");
                    sb.AppendLine($"{dob} {firstName} {lastName}");
                    var left = ele.Name.LocalName.Length + 5;
                    var fill = indent + "".PadLeft(left);
                    sb.AppendLine($"{fill}{address}");
                    sb.AppendLine($"{fill}{phoneNum}");
                    sb.AppendLine($"{fill}{city}");
                    sb.AppendLine($"{fill}{state}");
                    sb.AppendLine($"{fill}{country} />");
                    }
                else {
                    foreach (var attr in ele.Attributes()) {
                        sb.AppendFormat(" {0}", FormatAttr(attr));
                        }
                    }
                sb.AppendLine(">");
    
                foreach (var e in ele.Elements()) {
                    sb.Append(OutputElement(indentCnt + 1, e));
                    }
                sb.AppendLine($"{indent}</{ele.Name}>");
                return sb.ToString();
                }
    
            static void Main(string[] args) {
                var txtEle = @"
        <Details>
            <Name>
                <JohnDoe DOB = '10' FirstName = '20' LastName = '40'
                             Address = '50'
                             PhoneNum = '60'
                             City = '70'
                             State = '80'
                             Country = '90' />
            </Name>
        </Details>";
    
                var plib = new XElement("PersonLib");
                XDocument xdoc = new XDocument(plib);
                var nameEle = XElement.Parse(txtEle, LoadOptions.PreserveWhitespace);
                xdoc.Root.Add(nameEle);
    
                var xml = OutputElement(0, (XElement)xdoc.Root);
    
                Console.WriteLine(xml);
                }
            }
        }
