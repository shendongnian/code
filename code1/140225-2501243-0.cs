          var smAsm = AppDomain.CurrentDomain.GetAssemblies().First(a => a.FullName.StartsWith("System.ServiceModel,"));
            var defTy = smAsm.GetType("System.ServiceModel.Channels.EncoderDefaults");
            var rq = (System.Xml.XmlDictionaryReaderQuotas)defTy.GetField("ReaderQuotas", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).GetValue(null);
            rq.MaxArrayLength = int.MaxValue;
            rq.MaxDepth = int.MaxValue;
            rq.MaxNameTableCharCount = int.MaxValue;
            rq.MaxStringContentLength = int.MaxValue; 
