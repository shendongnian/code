    using System;
    using WMEncoderLib;
    class EncodeFile
    {
        static void Main()
        {
            try 
            {
                // Create a WMEncoder object.
                WMEncoder Encoder = new WMEncoder();
    
                // Retrieve the source group collection.
                IWMEncSourceGroupCollection SrcGrpColl = Encoder.SourceGroupCollection;
    
                // Add a source group to the collection.
                IWMEncSourceGroup SrcGrp  = SrcGrpColl.Add("SG_1");
    
                // Add a video and audio source to the source group.
                IWMEncSource SrcAud = SrcGrp.AddSource(WMENC_SOURCE_TYPE.WMENC_AUDIO);
                SrcAud.SetInput("C:\\Inputfile.mpg", "", "");
    
                IWMEncVideoSource2 SrcVid = (IWMEncVideoSource2)SrcGrp.AddSource(WMENC_SOURCE_TYPE.WMENC_VIDEO);
                SrcVid.SetInput("C:\\Inputfile.mpg", "", "");
    
                // Crop 2 pixels from each edge of the video image.
                SrcVid.CroppingBottomMargin = 2;
                SrcVid.CroppingTopMargin = 2;
                SrcVid.CroppingLeftMargin = 2;
                SrcVid.CroppingRightMargin = 2;
    
                // Specify a file object in which to save encoded content.
                IWMEncFile File = Encoder.File;
                File.LocalFileName = "C:\\OutputFile.wmv";
    
                // Choose a profile from the collection.
                IWMEncProfileCollection ProColl = Encoder.ProfileCollection;
                IWMEncProfile Pro;
                for (int i = 0; i < ProColl.Count; i++)
                {
                    Pro = ProColl.Item(i);
                    if (Pro.Name == "Windows Media Video 8 for Local Area Network (384 Kbps)")
                    {
                        SrcGrp.set_Profile(Pro);
                        break;
                    }
                }
    
                // Fill in the description object members.
                IWMEncDisplayInfo Descr = Encoder.DisplayInfo;
                Descr.Author = "Author name";
                Descr.Copyright = "Copyright information";
                Descr.Description = "Text description of encoded content";
                Descr.Rating = "Rating information";
                Descr.Title = "Title of encoded content";
    
                // Add an attribute to the collection.
                IWMEncAttributes Attr = Encoder.Attributes;
                Attr.Add ("URL", "IP address");
    
                // Start the encoding process.
                // Wait until the encoding process stops before exiting the application.
                Encoder.PrepareToEncode(true);
                Encoder.Start();
                Console.WriteLine("Press Enter when the file has been encoded.");
                Console.ReadLine(); // Press Enter after the file has been encoded.
            } 
            catch (Exception e) 
            {  
                // TODO: Handle exceptions.
            }
        }
    }
