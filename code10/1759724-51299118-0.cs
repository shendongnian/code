    public List<T> GetData<T>(string ControllersName, T DTOType)
    {         
         string Url = Settings.baseURLAddress + ControllersName;
         var request = (HttpWebRequest)HttpWebRequest.Create(Url);
         DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<T>));
         var response = (List<T>)serializer.ReadObject(request.GetResponse().GetResponseStream());
         return response;
    }
