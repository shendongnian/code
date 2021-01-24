    class Steps
    {
        private List<XElement> StepList;
    
        //Remove this, only needed inside GetStepData
        //private readonly XAttribute[] StepData;
    
        //Remove this, not needed
        //private int AmountOfSteps = 0;
    
        private readonly int AmountOfStepAttributes = 3;
    
        public Steps(XmlDoc xmlDoc)
        {
            StepList = xmlDoc.GetStepList();
        }
    
        public XAttribute[] GetStepData(XElement step)
        {
            //Create a new array here
            var StepData = new XAttribute[AmountOfStepAttributes];
            StepData[0] = step.Attribute("name");
            StepData[1] = step.Attribute("stepNo");
            StepData[2] = step.Attribute("colorCode");
    
            return StepData;
        }
    
        public List<XElement> stepList
        {
            get { return StepList; }
        }
    
        public int amountOfSteps
        {
            get
            {
                //Just directly return the count
                return stepList.Count();
            }            
        }
    
        public int amountStepAttributes
        {
            get { return AmountOfStepAttributes; }
        }
