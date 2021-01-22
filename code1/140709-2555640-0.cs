    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    using unoidl.com.sun.star.beans;
    using unoidl.com.sun.star.container;
    using unoidl.com.sun.star.frame;
    using unoidl.com.sun.star.lang;
    using unoidl.com.sun.star.table;
    using unoidl.com.sun.star.text;
    namespace OOApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                InitOpenOfficeEnvironment();
                XMultiServiceFactory multiServiceFactory = Connect();
                XComponent xComponent = null;
            
                string docFileName = @"C:\test3.doc";
    
                try
                {
                    XComponentLoader componentLoader =                 
                        (XComponentLoader)multiServiceFactory
                        .createInstance("com.sun.star.frame.Desktop");
                    //set the property
                    PropertyValue[] propertyValue = new PropertyValue[1];
                    PropertyValue aProperty = new PropertyValue();
                    aProperty.Name = "Hidden";
                    aProperty.Value = new uno.Any(false);
                    propertyValue[0] = aProperty;
                    xComponent =
                        componentLoader
                        .loadComponentFromURL(PathConverter(docFileName), 
                            "_blank", 0, propertyValue);
                    XTextDocument xTextDocument = ((XTextDocument)xComponent);
                    XEnumerationAccess xEnumerationAccess =    
                        (XEnumerationAccess)xTextDocument.getText();
                    XEnumeration xParagraphEnumeration = 
                        xEnumerationAccess.createEnumeration();
                    while (xParagraphEnumeration.hasMoreElements())
                    {
                        uno.Any element = xParagraphEnumeration.nextElement();
                        XServiceInfo xinfo = (XServiceInfo)element.Value;
                        if (xinfo.supportsService("com.sun.star.text.TextTable"))
                        {
                            Console.WriteLine("Found Table!");
                        
                            XTextTable xTextTable = (XTextTable)element.Value;
                            String[] cellNames = xTextTable.getCellNames();
                        
                            for (int i = 0; i < cellNames.Length; i++) 
                            {
                                XCell xCell = xTextTable.getCellByName(cellNames[i]);
                                XText xTextCell = (XText)xCell;
                                String strText = xTextCell.getString();
                                Console.WriteLine(strText);
                            } 
                        }
                        else
                        {
                            XTextContent xTextElement = (XTextContent)element.Value;
                            XEnumerationAccess xParaEnumerationAccess = 
                                (XEnumerationAccess)xTextElement;
                            // create another enumeration to get all text portions of 
                            //the paragraph
                            XEnumeration xTextPortionEnum = 
                                xParaEnumerationAccess.createEnumeration();
                            //step 3  Through the Text portions Enumeration, get interface 
                            //to each individual text portion
                            while (xTextPortionEnum.hasMoreElements())
                            {
                                XTextRange xTextPortion = 
                                    (XTextRange)xTextPortionEnum.nextElement().Value;
                                Console.Write(xTextPortion.getString());
                            }
                        }                    
                    }
                }
                catch (unoidl.com.sun.star.uno.Exception exp1)
                {
                    Console.WriteLine(exp1.Message);
                    Console.WriteLine(exp1.StackTrace);
                }
                catch(System.Exception exp2)
                {
                    Console.WriteLine(exp2.Message);
                    Console.WriteLine(exp2.StackTrace);
                }
                finally
                {
                    xComponent.dispose();
                    xComponent = null;
                }
                Console.WriteLine("Done.");
                Console.ReadLine();
            }
            static private void InitOpenOfficeEnvironment()
            {
                string baseKey;
                // OpenOffice being a 32 bit app, 
                //its registry location is different in a 64 bit OS
                if (Marshal.SizeOf(typeof(IntPtr)) == 8)
                    baseKey = @"SOFTWARE\Wow6432Node\OpenOffice.org\";
                else
                    baseKey = @"SOFTWARE\OpenOffice.org\";
                // Get the URE directory
                string key = baseKey + @"Layers\URE\1";
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(key);
                if (reg == null) reg = Registry.LocalMachine.OpenSubKey(key);
                string urePath = reg.GetValue("UREINSTALLLOCATION") as string;
                reg.Close();
                urePath = Path.Combine(urePath, "bin");
                // Get the UNO Path
                key = baseKey + @"UNO\InstallPath";
                reg = Registry.CurrentUser.OpenSubKey(key);
                if (reg == null) reg = Registry.LocalMachine.OpenSubKey(key);
                string unoPath = reg.GetValue(null) as string;
                reg.Close();
                string path;
                path = string.Format("{0};{1}",     
                    System.Environment.GetEnvironmentVariable("PATH"), urePath);
                System.Environment.SetEnvironmentVariable("PATH", path);
                System.Environment.SetEnvironmentVariable("UNO_PATH", unoPath);
            }
            public static XMultiServiceFactory Connect()
            {
                unoidl.com.sun.star.uno.XComponentContext m_xContext = null;
                try
                {
                    m_xContext = uno.util.Bootstrap.bootstrap();
                    System.Console.WriteLine("OO: bootstrap finished with success");
                }
                catch (System.Exception exp)
                {
                    System.Console.WriteLine("OO: Exception during bootstrap <" + 
                        exp.Message + ">");
                    System.Console.WriteLine("OO: Source" + exp.Source);
                    if (exp.InnerException != null)
                    {
                        System.Console.WriteLine("OO: Inner Message" + 
                            exp.InnerException.Message);
                        System.Console.WriteLine("OO: Inner Source" + 
                            exp.InnerException.Source);
                    }
                } 
                return (m_xContext != null) ? 
                    (XMultiServiceFactory)m_xContext.getServiceManager() : null;
            }
            private static string PathConverter(string file)
            {
                try
                {
                    file = file.Replace(@"\", "/");
                    return "file:///" + file;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
