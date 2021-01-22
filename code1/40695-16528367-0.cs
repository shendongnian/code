    using System;
    using System.Collections.Generic;
    using System.Windows.Forms; 
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Data;
    using System.Xml;
    namespace SiteMapReader
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Please Enter the Location of the file");
                // get the location we want to get the sitemaps from 
                string dirLoc = Console.ReadLine();
                // get all the sitemaps 
                string[] sitemaps = Directory.GetFiles(dirLoc);
                StreamWriter sw = new StreamWriter(Application.StartupPath + @"\locs.txt", true);
                // loop through each file 
                foreach (string sitemap in sitemaps)
                {
                    try
                    {
                        // new xdoc instance 
                        XmlDocument xDoc = new XmlDocument();
                        //load up the xml from the location 
                        xDoc.Load(sitemap);
                        // cycle through each child noed 
                        foreach (XmlNode node in xDoc.DocumentElement.ChildNodes)
                        {
                            // first node is the url ... have to go to nexted loc node 
                            foreach (XmlNode locNode in node)
                            {
                                // thereare a couple child nodes here so only take data from node named loc 
                                if (locNode.Name == "loc")
                                {
                                    // get the content of the loc node 
                                    string loc = locNode.InnerText;
                                    // write it to the console so you can see its working 
                                    Console.WriteLine(loc + Environment.NewLine);
                                    // write it to the file 
                                    sw.Write(loc + Environment.NewLine);
                                }
                            }
                        }
                    }
                    catch { }
                }
                Console.WriteLine("All Done :-)"); 
                Console.ReadLine(); 
            }
            static void readSitemap()
            {
            }
        }
    }
