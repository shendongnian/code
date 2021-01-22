    [return: System.Xml.Serialization.XmlElementAttribute("ResultWS", typeof(ResultWS), Namespace = "http://...")]
    [return: System.Xml.Serialization.XmlElementAttribute("ResultFaultWS", typeof(ResultFaultWS), Namespace = "http://...")]
    public object SumTest_Operation([System.Xml.Serialization.XmlElementAttribute(Namespace = "http://...")] ParamWS param)
    {            
        ResultWS result = null;
        try
        {
            result.Value = param.P1 + param.P2;              
                       
        }
        catch (Exception)
        {
            ResultFaultWS resultFault = new ResultFaultWS();
            resultFault.Status = noOK;
            return resultFault;;
        }
        return result;
    }    
