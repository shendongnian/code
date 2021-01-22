        XElement elements = XElement.Load("XMLFile.xml");
        List<HardwareSettings> hardwareSettingsList =
                    (from e in elements.Descendants("cameraSettings")
                    select new HardwareSettings
                    {
                        CameraSetting = new CameraSetting()
                            {
                                Depth = Convert.ToInt32(e.Attribute("width").Value),
                                Height = Convert.ToInt32(e.Attribute("width").Value),
                                Width = Convert.ToInt32(e.Attribute("width").Value)
                            },
                        TiltSettings = new TiltSettings() 
                            { } // your logic for rest of the structs
                    }).ToList<HardwareSettings>();
        int depth = 0;
        foreach (HardwareSettings hardwareSetting in hardwareSettingsList)
        {
            depth = hardwareSetting.CameraSetting.Depth;
        }
