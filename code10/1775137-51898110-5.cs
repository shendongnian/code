        public void ParseJsonResult(SomethingJsonResult result)
        {
            result?.updates?.ForEach(update =>
            {
                //(Attachment)update[6] works only when your properties 100% match json objects
                DataContractSerializer ser = new DataContractSerializer(typeof(Attachment));
                var attachment= (Attachment)ser.ReadObject(update[6]);
            });
        }
