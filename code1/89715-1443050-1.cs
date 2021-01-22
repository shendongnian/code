               string xmlFilePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "NetIQ.xml";
               FileInfo checkFile = new FileInfo(xmlFilePath);
               if (checkFile.Exists)
               { // True
                   readVal = ReadValFromXML(xmlFilePath);
                   if (!(readVal > 10 && readVal <= 600))
                   {
                       LeafDebug.DebugTraceNormal("InitializeComponent", "timer: 60sec");
                       readVal = 60000;
                   }
                   else
                   {
                       this.readVal = this.readVal * 1000;
                       LeafDebug.DebugTraceNormal("Modified interval is accepted.", "Set  timer to: " + (this.readVal / 1000) + ".");
                   }
               }
               else
               { // False
                   LeafDebug.DebugTraceNormal("InitializeComponent", "Set polling timer: 60sec");
                   readVal = 60000;
               }
               PassToTimer(readVal);
           }
           catch (Exception ex)
           {
               LeafDebug.DebugTraceSevere("The Error Occured in  file.", ex.ToString());
               LeafDebug.DebugTraceSevere(" Interval Error.", " interval value is not in correct format /  file not found.");
               LeafDebug.DebugTraceNormal("InitializeComponent", "Set  timer: 60sec");
               readVal = 60000;
               PassToTimer(readVal);
           }
    /// <summary>
       /// PassToTimer(int readVal): This function will pass the readVal to Timer
       /// </summary>
       /// <param name="readVal"></param>
       private void PassToTimer(int readVal)
       {
           timer = new System.Timers.Timer(readVal);
           timer.Elapsed += new ElapsedEventHandler(OnTimer);
           // The method in the Leaf.Resources instantiates the resource
           // manager appropriately to access the resource file.
           resources = Managers.LeafStrings;
       }
      /// <summary>
       /// ReadValFromXML(string path) : This Method will Read and returns the Pooling interval Value from NetIQPollingInterval.xml.
       /// </summary>
       /// <param name="path"> path determines the working directory of the application</param>
       /// <returns> Returns Pooling interval Value </returns>
       /// <creator> Created by Faishal </creator>
       /// <Date> 24th Aug '09 </Date>
       /// <ReasonForCreation> User can enter the Pooling Interval time by Modifying the value of file </ReasonForCreation>
       /// <xmlFileLocation> Project Folder </xmlFileLocation>
       private Int32 ReadValFromXML(string path)
       {
           XmlDocument xmlDoc = new XmlDocument();
           xmlDoc.Load(path);
           XmlNode node = xmlDoc.SelectSingleNode("Time");
           Int32 val = Int32.Parse(node.FirstChild.InnerText.ToString());
           return val;
       }
