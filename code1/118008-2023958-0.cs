        protected static ImportTest.CandidateService.ProcessCandidateType DeserializeProcessCandidate(string path)
        {
            CandidateService.ProcessCandidateType processCandidate = null;
            XmlRootAttribute root = new XmlRootAttribute("ProcessCandidate");
            XmlSerializer serializer = new XmlSerializer(typeof(CandidateService.ProcessCandidateType), new XmlAttributeOverrides(), new Type[0], root, "http://www.hr-xml.org/3");
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(path);
                processCandidate = (CandidateService.ProcessCandidateType)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                reader.Close();
                throw (new Exception(ex.InnerException.Message));
            }
            return processCandidate;
        }
