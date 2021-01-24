    public IEnumerator ReadData(String source) {
            using (UnityWebRequest webClient = UnityWebRequest.Get(source))
            {
                loaded = false;
                yield return webClient.SendWebRequest();
                byte[] bytes = webClient.downloadHandler.data;
                data = Encoding.UTF8.GetString(bytes);
                loaded = true;
                if (data == null||data.Equals(""))
                {
                    throw new ArgumentNullException("Data", "No Data recieved from service");
                }
            }
          
        }
