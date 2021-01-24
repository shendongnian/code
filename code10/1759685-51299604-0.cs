    public static void StoreResult(List<LabPostResult> labPostResultList)
        {
            var xml = new XElement("LabPostResult", 
                                    labPostResultList.Select(x => new XElement("row",
                                             new XAttribute("PatientID", x.PatientID),
                                             x.AnalyteName.ToXElement("AnalyteName"),
                                             x.Loinc.ToXElement("TestName")
                                                   )));
        }
