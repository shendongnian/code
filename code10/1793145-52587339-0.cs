    private XDocument xDoc;
    private bool SignalDataInfo(string fileName)
            {
                if(xDoc == null){
                   xDoc = XDocument.Load(fileName);
                }
                if (xDoc != null)
                {
                    var signalData = xDoc.Descendants("SignalData");
                    foreach (var signal in signalData)
                    {
                        var width = signal.Attribute("DataWidth").Value;
                        string dataWidth = width.Substring(0, width.IndexOf(" "));
                        var period = signal.Attribute("SamplingPeriod").Value;
                        string samplingPeriod = period.Substring(0, period.IndexOf(" "));
                        SignalData(fileName,dataWidth, samplingPeriod);
                    }
                    return true;
                }
                else
                    return false;
            }
    
    public bool SignalData(string fileName,string width, string period)
            {
                if(xDoc == null){
                   xDoc = XDocument.Load(fileName);
                }
                if (xDoc != null)
                {
                    var signalData = xDoc.Descendants("Signal");
    
                    foreach (var signal in signalData)
                    { // extract data from every signal }
    return true;
    else false;
    }
