        public void ParseJsonResult(SomethingJsonResult result)
        {
            result?.updates?.ForEach(update =>
            {
                //(Attachment)update[6] works only when your names of properties 100% match json objects
                DataContractSerializer ser = new DataContractSerializer(typeof(Attachment));
                var attachment= ser.ReadObject(update[6]) as Attachment;
                ....
            });
        }
